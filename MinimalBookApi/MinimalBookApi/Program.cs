using Microsoft.AspNetCore.Builder;
using MinimalBookApi;
using static System.Reflection.Metadata.BlobBuilder;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/GetAll", async (DataContext context) => 

    await context.Books.ToListAsync());



app.MapGet("/get/{id}", async (DataContext context, int id) =>
    await context.Books.FindAsync(id) is Book book ?
        Results.Ok(book) : Results.NotFound("Livro não encontrado."));


app.MapPost("/post", async (DataContext context , Book book) => {

    context.Books.Add(book);
    await context.SaveChangesAsync();
    return Results.Ok(await context.Books.ToListAsync());

});

app.MapPut("/update/{id}", async (DataContext context, Book updatedBook, int id) => {
   
    var book = await context.Books.FindAsync(id);
    if (book is null)
    {
        return Results.NotFound("Livro: " + id + "não encontrado");
    }
    book.Title = updatedBook.Title;
    book.Author = updatedBook.Author;
    await context.SaveChangesAsync();


    return Results.Ok(await context.Books.ToListAsync());
});

app.MapDelete("/delete/{id}", async (DataContext context, int id) => {
    var book = await context.Books.FindAsync(id);
    if (book is null)
    {
        return Results.NotFound("Livro não encontrado");
    }

    context.Books.Remove(book);
    await context.SaveChangesAsync();


    return Results.Ok(await context.Books.ToListAsync());
});

//Console.WriteLine("Easter Egg do programa aqui");
app.Run();
public class Book
{
    public int id { get; set; }
    public required string Title { get; set; }
    public required string Author { get; set; }

}






/*

MINIMAL API 7


using Microsoft.AspNetCore.Builder;
using MinimalBookApi;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var books = new List<Book>
{
    new Book { id = 1 , Title = "The Hitchhiker's Guide to the Galaxy" , Author = "Douglas Adams"},
    new Book { id = 2 , Title = "1984" , Author = "George Orwell"},
    new Book { id = 3 , Title = "Ready Player One" , Author = "Ernest Cline"},
    new Book { id = 4 , Title = "The Martian" , Author = "Andy Weir"},
};




app.MapGet("/book", () =>
{
    return books;

});

app.MapGet("/book/{id}", (int id) =>
{
    var book = books.Find(b => b.id == id);
    if (book is null)
        return Results.NotFound("Livro não encontrado");




    return Results.Ok(book);
});


app.MapPost("/book", (Book book) => {

    books.Add(book);
    return books;

});

app.MapPut("/book/{id}", (Book updatedBook, int id) => {
    var book = books.Find(b => b.id == id);
    if (book is null)
    {
        return Results.NotFound("Livro não encontrado");
    }
    book.Title = updatedBook.Title;
    book.Author = updatedBook.Author;



    return Results.Ok(book);
});

app.MapDelete("/book/{id}", (int id) => {
    var book = books.Find(b => b.id == id);
    if (book is null)
        return Results.NotFound("Livro não encontrado");

    books.Remove(book);



    return Results.Ok(book);
});

app.Run();
public class Book
{
    public int id { get; set; }
    public required string Title { get; set; }
    public required string Author { get; set; }

}
*/