using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetShop.Model
{
    public class Pet
    {

        public int Id { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public string Raca { get; set; }
        public string Vacinacao { get; set; }
        public string Donos { get; set; }
        public string Tipo { get; set; }

    }
}