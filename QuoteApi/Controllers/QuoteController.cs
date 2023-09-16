using Domain.Dtos.QuoteDto;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace QuoteApi.Controllers;

[ApiController]
[Route("[controller]")]
public class QuoteController
{
    private QuoteService _quoteService;

    public QuoteController()
    {
        _quoteService = new QuoteService();
    }

    [HttpPost("AddQuote")]
    public string AddQuote(AUQuoteDto quote)
    {
        return _quoteService.AddQuote(quote);
    }

    [HttpPut("UpdateQuote")]
    public string UpdateQuote(AUQuoteDto quote)
    {
        return _quoteService.UpdateQuote(quote);
    }

    [HttpDelete("DeleteQuote")]
    public string DeleteQuote(int id)
    {
        return _quoteService.DeleteQuote(id);
    }

    [HttpGet("GetAllQuotes")]
    public List<GQuoteDto> GetAllQuotes()
    {
        return _quoteService.GetAllQuotes();
    }

    [HttpGet("GetQuoteById")]
    public GQuoteDto GetQuoteById(int id)
    {
        return _quoteService.GetQuoteById(id);
    }

    [HttpGet("GetAllQuotesWithCategoryName")]
    public List<GetAllQuotesWithCategoryNameDto> GetAllQuotesWithCategoryName()
    {
        return _quoteService.GetAllQuotesWithCategoryName();
    }

    [HttpGet("GetAllQuotesByCategoryId")]
    public List<GQuoteDto> GetAllQuotesByCategoryId(int id)
    {
        return _quoteService.GetAllQuotesByCategoryId(id);
    }

    [HttpGet("GetRandomQuote")]
    public GQuoteDto GetRandomQuote()
    {
        return _quoteService.GetRandomQuote();
    }

    [HttpGet("GetAllAuthors")]
    public List<GetAllAuthorsDto> GetAllAuthors()
    {
        return _quoteService.GetAllAuthors();
    }

    [HttpGet("GetAmountOfAuthorsAndQuotes")]
    public GetAmountAQ GetAmountOfAuthorsAndQuotes()
    {
        return _quoteService.GetAmountOfAuthorsAndQuotes();
    }

    [HttpGet("GetQuotesByQuoteText")]
    public List<GQuoteDto> GetQuotesByQuoteText(string quoteText)
    {
        return _quoteService.GetQuotesByQuoteText(quoteText);
    }

    [HttpGet("GetTopAuthors")]
    public List<GetTopAuthorsDto> GetTopAuthors()
    {
        return _quoteService.GetTopAuthors();
    }
}
