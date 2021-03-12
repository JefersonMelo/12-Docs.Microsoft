using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoPets.Api.Models
{
    public class Produto
    {
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string Descricao { get; set; }

        [Range(0.01, 9999.99)]
        public decimal Preco { get; set; }
    }
}
