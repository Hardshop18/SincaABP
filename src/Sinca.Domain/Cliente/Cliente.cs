using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace Sinca
{
    public class Cliente : AuditedAggregateRoot<Guid>, ICliente
    {
        public string Nome { get; set; }
        public string Observacao { get; set; }

        public static Cliente Novo(string nome)
        {
            var novo = new Cliente();
            novo.Id = Guid.NewGuid();
            novo.Nome = nome;
            novo.Observacao = "Obs";
            return novo;
        }

        public Cliente() : base( Guid.NewGuid())
        {

        }
    }
}
