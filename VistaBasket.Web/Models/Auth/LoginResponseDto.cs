﻿namespace VistaBasket.Web.Models.Auth
{
    public class LoginResponseDto
    {
        public string? Token { get; set; }
        public UserDto User { get; set; }
    }
}
