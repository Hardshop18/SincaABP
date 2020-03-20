using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Volo.Abp.Domain.Entities;

namespace Volo.Abp.TestApp2.Domain
{
    [Table("AppPhones")]
    public class Phone : Entity<string>
    {
        public virtual string PersonId { get; set; }

        public virtual string Number { get; set; }

        public virtual PhoneType Type { get; set; }

        private Phone()
        {

        }

        public Phone(string personId, string number, PhoneType type = PhoneType.Mobile)
        {
            Id = Guid.NewGuid().ToString();
            PersonId = personId;
            Number = number;
            Type = type;
        }

        public override object[] GetKeys()
        {
            return new object[] { PersonId, Number };
        }
    }

    public class Order : AggregateRoot<string>
    {
        public virtual string ReferenceNo { get; protected set; }

        public virtual float TotalItemCount { get; protected set; }

        public virtual DateTime CreationTime { get; protected set; }

        public virtual List<OrderLine> OrderLines { get; protected set; }

        protected Order()
        {

        }

        public Order(string id, string referenceNo)
            : base(id)
        {
            ReferenceNo = referenceNo;
            OrderLines = new List<OrderLine>();
        }

        public void AddProduct(string productId, int count)
        {
            if (count <= 0)
            {
                throw new ArgumentException("You can not add zero or negative count of products!", nameof(count));
            }

            var existingLine = OrderLines.FirstOrDefault(ol => ol.ProductId == productId);

            if (existingLine == null)
            {
                OrderLines.Add(new OrderLine(this.Id, productId, count));
            }
            else
            {
                existingLine.ChangeCount(existingLine.Count + count);
            }

            TotalItemCount += count;
        }
    }

    public class OrderLine : Entity<string>
    {
        public virtual string OrderId { get; protected set; }

        public virtual string ProductId { get; protected set; }

        public virtual int Count { get; protected set; }

        protected OrderLine()
        {

        }

        public OrderLine(string orderId, string productId, int count)
        {
            OrderId = orderId;
            ProductId = productId;
            Count = count;
        }

        internal void ChangeCount(int newCount)
        {
            Count = newCount;
        }

        public override object[] GetKeys()
        {
            return new object[] { OrderId, ProductId };
        }
    }
}