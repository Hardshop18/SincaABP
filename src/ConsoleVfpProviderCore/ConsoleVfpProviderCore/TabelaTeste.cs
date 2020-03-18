using System.ComponentModel.DataAnnotations;

namespace ConexaoVFPCore
{
    public class TabelaTeste
    {
        [Key]
        public int id { get; set; }
        public string nome { get; set; } 
    }
}
