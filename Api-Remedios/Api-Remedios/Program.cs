using Api_Remedios.Data;
using Api_Remedios.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System;
using System.Net.Http;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<RemediosDbContext>();
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

//builder.Services.AddDbContext<DataContext>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();





var remedios = new List<Remedios>
{ 
    new Remedios {Id = 1, Nome ="Novalgina" , Vaga_lote = "Alfa beta gama" , Hora_Cadastro= DateTime.Now ,Link_Bula = ""}

};

var Unidades = new List<Unidades>
{
    new Unidades {Id = 1, Nome = "Mario Monteiro"}
};


/*
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
 */


app.MapGet("/remedios", async (RemediosDbContext context) =>
{
    var remedios = await context.Remedios.ToListAsync();
    if(remedios == null)
    {

        return Results.NotFound("Não existem remédios cadastrados ou com valor tangível.");  //"Não Localizado";

    }

    return Results.Ok(remedios);
});

app.MapGet("/remedios/{id}", (int id) =>
{
    var remedio = remedios.Find(r => r.Id == id);

    if(remedio == null)
    {
        return Results.NotFound("Nao existe esse remedio de id: " + id);
    }

    return Results.Json(remedio);
});

app.MapPost($"/remedios/", (Remedios remedio) => 
{
    if (remedio is not null)
    {
        remedios.Add(remedio);
        return Results.Ok(remedio);
    }
    else
    {
        return Results.BadRequest("Remedio não encontrado");
    }



});




app.MapGet("/Files/UploadFiles", async (IFormFile file ) =>
{

    string filepatch = "upload/" + file.FileName;
    using var stream = File.OpenWrite(filepatch);
    await file.CopyToAsync(stream);
    if(file == null)
    {

        return Results.BadRequest("Sem fotos a enviar");
    }
    return Results.Ok(file);
    // if (!request.Form.Files.Any())
    //     return Results.BadRequest("Precisa enviar um arquivo");
    // foreach(var file in request.Form.Files)
    // {
    //    using(var stream = new FileStream(@"c:\Temp\UploadedFiles" + file.FileName,FileMode.Create))
    //    {
    //        file.CopyTo(stream);
    //     }
    /// }
    // return Results.Ok("arquivo enviado com sucesso");

});

app.MapPost("/Files/UploadFiles", async (IFormFile file ) =>
{

    string filepatch = "upload/" + file.FileName;
    using var stream = File.OpenWrite(filepatch);
    await file.CopyToAsync(stream);




    // if (!request.Form.Files.Any())
    //     return Results.BadRequest("Precisa enviar um arquivo");
    // foreach(var file in request.Form.Files)
    // {
    //    using(var stream = new FileStream(@"c:\Temp\UploadedFiles" + file.FileName,FileMode.Create))
    //    {
    //        file.CopyTo(stream);
    //     }
    /// }
    // return Results.Ok("arquivo enviado com sucesso");

});

app.MapPut("/remedios", (Remedios RemediosAtualiza, int id) =>
{
    var remedio = remedios.Find(r => r.Id == id);
    if (remedio is null)
    {
        return Results.NotFound("Nao existe esse remedio de id: " + id);
    }

    remedio.Id = RemediosAtualiza.Id;
    remedio.Nome = RemediosAtualiza.Nome;
    remedio.Link_Bula = RemediosAtualiza.Link_Bula;

    return Results.Ok(remedio);

});

app.MapDelete("/remedios/{id}",  (int id) =>
{
    var remedio = remedios.Find(r =>r.Id == id);
    if(remedio is null)
    {
        return Results.NotFound("Nao existe esse remedio de id: " + id);
    }

    remedios.Remove(remedio);

    return Results.Ok(remedio);

});

app.Run();



