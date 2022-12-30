using System;
using System.Collections.Generic;
using System.Text;
namespace Core.Entities.Concrete
{
    public class User : IEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public string CellPhone { get; set; }
        public string ProfileImage { get; set; }
        public int CityId { get; set; }
        public string Email { get; set; }
        public string AboutMe { get; set; }
        public string Cv { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }
        public bool Status { get; set; }
    }
}
