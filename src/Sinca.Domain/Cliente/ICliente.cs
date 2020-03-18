using System;
using Volo.Abp.Domain.Entities;

namespace Sinca
{
    public interface ICliente : IAggregateRoot<Guid>, IEntity<Guid>, IEntity, IAggregateRoot
    {
        public string Nome { get; set; }
        public string Observacao { get; set; }
    }
}
