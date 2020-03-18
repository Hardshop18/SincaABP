using System;
using Volo.Abp.Application.Dtos;

namespace Sinca
{
    public class ClienteDto : AuditedEntityDto<Guid>
    {
        public string Nome { get; set; }
        public string Observacao { get; set; }

        public static ClienteDto Novo(string nome)
        {
            var novo = new ClienteDto();
            novo.Nome = nome;
            novo.Observacao = "Obs";
            return novo;
        }
    }
}
