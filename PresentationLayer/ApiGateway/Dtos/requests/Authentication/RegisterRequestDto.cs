namespace rick_morty_app.Dtos
{
    public class RegisterRequestDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public RegisterRequestDto(string name, string email, string password)
        {
            Name = name;
            Email = email;
            Password = password;
        }
    }
}