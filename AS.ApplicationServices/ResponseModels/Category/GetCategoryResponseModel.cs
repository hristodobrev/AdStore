namespace AS.ApplicationServices.ResponseModels.Category
{
    public class GetCategoryResponseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int RatingGained { get; set; }
        public int RequiredRating { get; set; }
        public bool IsRequiringPremium { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
