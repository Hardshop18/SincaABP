﻿using System.ComponentModel.DataAnnotations;

namespace Sinca.VfpProviderCore
{
    public class TabelaTeste
    {
        [Key]
        public int id { get; set; }
        public string nome { get; set; }
    }
}