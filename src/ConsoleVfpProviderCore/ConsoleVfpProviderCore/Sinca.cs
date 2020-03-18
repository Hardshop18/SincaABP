using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ConexaoVFPCore
{
    public class Sinca
    {
        [Key]
        public int id { get; set; }
        public string nome { get; set; } 
    }
}
