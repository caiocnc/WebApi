namespace WebApi.Models
{
    public class AddUserRequest
    {
        public string email { get; set; }
        public string password { get; set; }
        public string cpf { get; set; }
    }
}
