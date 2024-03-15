namespace AS.ApplicationServices.ResponseModels.Auth
{
    public class AuthResponseModel
    {
        public string Token { get; set; }
        public string Username { get; set; }
        public DateTime ExpireDate { get; set; }
    }
}
