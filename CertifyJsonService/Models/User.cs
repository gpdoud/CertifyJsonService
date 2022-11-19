using System;
namespace CertifyJsonService.Models
{
    public class User
    {
        public int Id { get; set; } = 0;
        public string Username { get; set; } = "";
        public string Password { get; set; } = "";
        public string Firstname { get; set; } = "";
        public string Lastname { get; set; } = "";
        public string? Phone { get; set; } = null;
        public string? Email { get; set; } = null;
        public bool IsReviewer { get; set; } = false;
        public bool IsAdmin { get; set; } = false;

        public override string ToString() {
            return $"{Id}|{Username}|{Firstname} {Lastname}|{Phone}|{Email}|{IsReviewer}|{IsAdmin}";
        }
    }
}

