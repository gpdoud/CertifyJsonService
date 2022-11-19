using System;
namespace CertifyJsonService.Models
{
    public class Vendor
    {
        public int Id { get; set; } = 0;
        public string Code { get; set; } = "";
        public string Name { get; set; } = "";
        public string Address { get; set; } = "";
        public string City { get; set; } = "";
        public string State { get; set; } = "";
        public string Zip { get; set; } = "";
        public string? Phone { get; set; } = null;
        public string? Email { get; set; } = null;

        public override string ToString() {
            return $"{Id}|{Code}|{Name}|{Address}, {City}, {State} {Zip}|{Phone ?? "(null)"}|{Email ?? "(null)"}";
        }
    }
}

