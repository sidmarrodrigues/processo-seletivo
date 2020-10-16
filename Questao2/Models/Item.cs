using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Questao2.Models
{
    public class Item
    {
        public int Id { get; set; }
        public int CodigoItem { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
    }
}