using Npgsql;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Example: Query PostgreSQL using Npgsql
string connString = builder.Configuration.GetConnectionString("DefaultConnection");

using (var conn = new NpgsqlConnection(connString))
{
    conn.Open();
    Console.WriteLine("Connected to PostgreSQL successfully!");

    // Example query
    using var cmd = new NpgsqlCommand("SELECT id, name, price FROM dish;", conn);
    using var reader = cmd.ExecuteReader();
    while (reader.Read())
    {
        Console.WriteLine($"Dish: {reader.GetInt64(0)} - {reader.GetString(1)} - {reader.GetDouble(2)}");
    }
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
