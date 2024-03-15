namespace AS.ApplicationServices.ResponseModels.Auth
{
    public class AuthServiceModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public int Rating { get; set; }
        public bool IsPremium { get; set; }
        public bool IsAdmin { get; set; }
    }
}
