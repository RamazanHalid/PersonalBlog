using Core.Entities; 
namespace Entities.DTOs
{
    public class UserForRegisterDto : IDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordConfirim { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title{ get; set; }
        public string CellPhone{ get; set; }
        public bool DoesAgreeTermsAndPolicy { get; set; }
    }
}
