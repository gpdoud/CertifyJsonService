using System;
namespace CertifyJsonService.Models
{
    public class Product
    {
        public int Id { get; set; } = 0;
        public string PartNbr { get; set; } = "";
        public string Name { get; set; } = "";
        public decimal Price { get; set; } = 0;
        public string Unit { get; set; } = "";
        public string Photopath { get; set; } = "";

        public override string ToString() {
            return $"{Id}|{Name}({PartNbr})|{Price:C}|{Unit}|{Photopath}";
        }
    }
}

