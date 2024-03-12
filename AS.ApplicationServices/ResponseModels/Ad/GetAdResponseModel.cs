namespace AS.ApplicationServices.ResponseModels.Ad
{
    public class GetAdResponseModel
    {

        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public bool IsActive { get; set; }
        public bool IsSold { get; set; }
        public DateTime DateCreated { get; set; }

        public string CategoryName { get; set; }
        public string Username { get; set; }
        public string Town { get; set; }
    }
}
