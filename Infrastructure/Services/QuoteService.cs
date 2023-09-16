using Dapper;
using Domain.Dtos.QuoteDto;
using Npgsql;
using System.Globalization;

namespace Infrastructure.Services;

public class QuoteService
{
    string connectionString = "Server = localhost; Port = 5432; Database = QuoteDapperDemoDb; User Id = postgres; Password = masik00787737;";

    public QuoteService()
    {

    }

    //Add Quote
    public string AddQuote(AUQuoteDto quote)
    {
        using (var conn = new NpgsqlConnection(connectionString))
        {
            var command = " insert into quotes(author, quotetext, categoryid) " +
                          " values (@Author, @QuoteText, @CategoryId);";

            var result = conn.Execute(command, new
            {
                Author = quote.Author,
                QuoteText = quote.QuoteText,
                CategoryId = quote.CategoryId
            });

            return $"Successfully added: {result}";
        }
    }

    //Update Quote
    public string UpdateQuote(AUQuoteDto quote)
    {
        using (var conn = new NpgsqlConnection(connectionString))
        {
            var command = " update quotes " +
                          " set author = @Author, quotetext = @QuoteText, categoryid = @CategoryId " +
                          " where id = @Id;";

            var result = conn.Execute(command, new
            {
                Id = quote.Id,
                Author = quote.Author,
                QuoteText = quote.QuoteText,
                CategoryId = quote.CategoryId
            });

            return $"Successfully updated: {result}";
        }
    }

    //Delete Quote
    public string DeleteQuote(int id)
    {
        using (var conn = new NpgsqlConnection(connectionString))
        {
            var command = " delete from quotes " +
                          " where id = @Id;";

            var result = conn.Execute(command, new
            {
                Id = id
            });

            return $"Successfully deleted: {result}";
        }
    }

    //Get All Quotes
    public List<GQuoteDto> GetAllQuotes()
    {
        using (var conn = new NpgsqlConnection(connectionString))
        {
            var command = " select * from quotes; ";

            var result = conn.Query<GQuoteDto>(command);

            return result.ToList();
        }
    }

    //Get Quote by Id
    public GQuoteDto GetQuoteById(int id)
    {
        using (var conn = new NpgsqlConnection(connectionString))
        {
            var command = "select * from quotes " +
                          " where id = @Id;";

            var result = conn.QuerySingle<GQuoteDto>(command, new
            {
                Id = id
            });

            return result;
        }
    }

    //Get list of Quotes including CategoryName
    public List<GetAllQuotesWithCategoryNameDto> GetAllQuotesWithCategoryName()
    {
        using (var conn = new NpgsqlConnection(connectionString))
        {
            var command = "select q.id, q.author, q.quotetext, q.categoryid, c.categoryname " +
                " from quotes as q " +
                " join categories as c " +
                " on q.categoryid = c.id;";

            var result = conn.Query<GetAllQuotesWithCategoryNameDto>(command);

            return result.ToList();
        }
    }

    //Get all quotes by category (send category id and get all quotes)
    public List<GQuoteDto> GetAllQuotesByCategoryId(int id)
    {
        using (var conn = new NpgsqlConnection(connectionString))
        {
            var command = " select * from quotes " +
                          " where categoryid = @Id;";

            var result = conn.Query<GQuoteDto>(command, new
            {
                Id = id
            });

            return result.ToList();
        }
    }

    //Get a random quote
    public GQuoteDto GetRandomQuote()
    {
        using (var conn = new NpgsqlConnection(connectionString))
        {
            var command = " select * from quotes " +
                          " order by random() " +
                          " limit 1;";

            var result = conn.QuerySingle<GQuoteDto>(command);

            return result;
        }
    }

    //Get all Authors with number of quotes
    public List<GetAllAuthorsDto> GetAllAuthors()
    {
        using (var conn = new NpgsqlConnection(connectionString))
        {
            var command = " select author, count(quotetext) as quoteamount " +
                " from quotes " +
                " group by author;";

            var result = conn.Query<GetAllAuthorsDto>(command);

            return result.ToList();
        }
    }

    //Get number of Authors and number of Quotes
    public GetAmountAQ GetAmountOfAuthorsAndQuotes()
    {
        using (var conn = new NpgsqlConnection(connectionString))
        {
            var command = " select count(author) as authoramount, count(quotetext) as quoteamount " +
                          " from quotes;";

            var result = conn.QuerySingleOrDefault<GetAmountAQ>(command);

            return result;
        }
    }

    //Get Quotes filtering with quote text
    public List<GQuoteDto> GetQuotesByQuoteText(string text)
    {
        using (var conn = new NpgsqlConnection(connectionString))
        {
            var command = " select * " +
                          " from quotes " +
                         $" where lower(quotetext) like '%{text.ToLower()}%';";

            var result = conn.Query<GQuoteDto>(command);

            return result.ToList();
        }
    }

    //Get top 10 most popular authors
    public List<GetTopAuthorsDto> GetTopAuthors()
    {
        using (var conn = new NpgsqlConnection(connectionString))
        {
            var command = " select author " +
                          " from quotes " +
                          " group by author " +
                          " order by count(quotetext) desc " +
                          " limit 10 " +
                          " offset 0;";

            var result = conn.Query<GetTopAuthorsDto>(command);

            return result.ToList();
        }
    }
}
