using System;
namespace CertifyJsonService.Models
{
    public class User
    {
        public static User NewUser = new User
        {
            Id = 0,
            Username = $"zz{Random.Shared.Next()}",
            Password = "zz",
            Firstname = "zz",
            Lastname = "zz",
            Phone = "911",
            Email = "help@me.com",
            IsReviewer = true,
            IsAdmin = false
        };

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
            return $"{Id,3} | {Username,-15} | {Firstname + ' ' + Lastname,-20}" +
                    $" | {Phone,-12} | {Email,-15} | {(IsReviewer?'T':'F')} | {(IsAdmin?'T':'F')}";
        }
    }
}

