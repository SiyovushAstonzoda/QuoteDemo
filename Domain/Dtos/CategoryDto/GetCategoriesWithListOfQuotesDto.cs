namespace Domain.Dtos.CategoryDto;

public class GetCategoriesWithListOfQuotesDto
{
    public int Id { get; set; }
    public string CategoryName { get; set; }

    public string QuoteText { get; set; }
}

