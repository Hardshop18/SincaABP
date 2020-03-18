using System.ComponentModel.DataAnnotations;

namespace Sinca
{
    public class CreateUpdateClienteDto
    {
        [Required]
        [StringLength(128)]
        public string Nome { get; set; }
        [Required]
        [StringLength(200)]
        public string Observacao { get; set; }
    }
}
