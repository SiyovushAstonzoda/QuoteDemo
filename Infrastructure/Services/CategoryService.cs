using Dapper;
using Domain.Dtos.CategoryDto;
using Npgsql;

namespace Infrastructure.Services;

public class CategoryService
{
    string connectionString = "Server = localhost; Port = 5432; Database = QuoteDapperDemoDb; User Id = postgres; Password = masik00787737;";

    public CategoryService()
    {
        
    }

    //Add Category
    public string AddCategory(AUCategoryDto category)
    {
        using (var conn = new NpgsqlConnection(connectionString))
        {
            var command = $"insert into Categories (categoryname) " +
                $"values (@CategoryName)";

            var result = conn.Execute(command, new
            {
                CategoryName = category.CategoryName
            });

            return $"Successfully added: {result}";
        }
    }

    //Update Category
    public string UpdateCategory(AUCategoryDto category)
    {
        using (var conn = new NpgsqlConnection(connectionString))
        {
            var command = "update Categories " +
                "set categoryname = @CategoryName " +
                "where id = @Id";

            var result = conn.Execute(command, new
            {
                Id = category.Id,
                CategoryName = category.CategoryName
            });

            return $"Successfully updated: {result}";
        }
    }

    //Delete Category
    public string DeleteCategory(int id)
    {
        using (var conn = new NpgsqlConnection(connectionString))
        {
            var command = "delete from Categories " +
                "where id = @Id;";

            var result = conn.Execute(command, new
            {
                Id = id
            });

            return $"Successfully deleted: {result}";
        }
    }

    //Get all categories
    public List<GCategoryDto> GetAllCategories()
    {
        using (var conn = new NpgsqlConnection(connectionString))
        {
            var command = " select * from categories ";

            var result = conn.Query<GCategoryDto>(command);

            return result.ToList();
        }
    }

    //Get Category By Id
    public GCategoryDto GetCategoryById(int id)
    {
        using (var conn = new NpgsqlConnection(connectionString))
        {
            var command = " select * from categories where id = @Id ";

            var result = conn.QuerySingleOrDefault<GCategoryDto>(command, new
            {
                Id = id
            });

            return result;
        }
    }

    //Get all Categories with number of quotes
    public List<GetAllCategoriesWithNumberOfQuotesDto> GetAllCategoriesWithNumberOfQuotes()
    {
        using (var conn = new NpgsqlConnection(connectionString))
        {
            var command = " select c.id, c.categoryname, count(q.id) as TotalQuotes " +
                " from categories as c " +
                " left join quotes as q " +
                " on c.id = q.categoryid " +
                " group by c.categoryname, c.id " +
                " order by TotalQuotes desc; ";

            var result = conn.Query<GetAllCategoriesWithNumberOfQuotesDto>(command);

            return result.ToList();
        }
    }

    //Get Categories including list of quotes in it
    public List<GetCategoriesWithListOfQuotesDto> GetCategoriesWithListOfQuotes()
    {
        using (var conn = new NpgsqlConnection(connectionString))
        {
            var command = "select c.id, c.categoryname, q.quotetext " +
                " from categories as c " +
                " join quotes as q " +
                " on c.id = q.categoryid;";

            var result =  conn.Query<GetCategoriesWithListOfQuotesDto>(command);

            return result.ToList();
        }
    }
}
