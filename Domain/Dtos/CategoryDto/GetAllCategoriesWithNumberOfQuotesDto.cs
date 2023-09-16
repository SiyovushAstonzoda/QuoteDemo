namespace Domain.Dtos.CategoryDto;

public class GetAllCategoriesWithNumberOfQuotesDto
{
    public int Id { get; set; }
    public string CategoryName { get; set; }

    public int TotalQuotes { get; set; }
}
