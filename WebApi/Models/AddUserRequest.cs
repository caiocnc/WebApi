﻿namespace WebApi.Models
{
    public class AddUserRequest
    {
        public string email { get; set; }
        public string senha { get; set; }
        public string cpf { get; set; }
    }
}
