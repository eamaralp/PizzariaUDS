﻿using System.ComponentModel.DataAnnotations;

namespace PizzariaUDS.Models
{
    public class Sabor : ItemPizza
    {
        [Key]
        public int SaborId { get; set; }
    }
}