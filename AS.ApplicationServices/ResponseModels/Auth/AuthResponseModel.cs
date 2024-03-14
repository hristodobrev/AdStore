namespace AS.ApplicationServices.ResponseModels.Auth
{
    public class AuthResponseModel
    {
        public int Id { get; set; }
        public int Rating { get; set; }
        public bool IsPremium { get; set; }
        public bool IsAdmin { get; set; }
    }
}
