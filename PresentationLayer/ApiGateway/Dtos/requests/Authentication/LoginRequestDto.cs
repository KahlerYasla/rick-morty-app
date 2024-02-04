namespace rick_morty_app.Dtos
{
    public class LoginRequestDto
    {
        public string Name { get; set; }
        public string Password { get; set; }

        public LoginRequestDto(string name, string password)
        {
            Name = name;
            Password = password;
        }
    }
}