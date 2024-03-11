namespace AS.ApplicationServices.ResponseModels.User
{
    public class GetUserResponseModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Town { get; set; }
        public int Rating { get; set; }
        public bool IsPremium { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
