using System.ComponentModel.DataAnnotations;

namespace ConsoleVFPCore
{
    public class TabelaTeste
    {
        [Key]
        public int id { get; set; }
        public string nome { get; set; } 
    }
}
