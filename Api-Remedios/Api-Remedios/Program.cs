global using Api_Remedios.Models;
using Api_Remedios;
using Api_Remedios.Data;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System;
using System.Net.Http;
using static System.Reflection.Metadata.BlobBuilder;

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




var remedios = new List<Remedios> {};

var Unidades = new List<Unidades> {};

/*
var remedios = new List<Remedios>
{ 
    new Remedios {Id = 1, Nome ="Novalgina" , Vaga_lote = "Alfa beta gama" , Hora_Cadastro= DateTime.Now ,Link_Bula = ""}

};

var Unidades = new List<Unidades>
{
    new Unidades {Id = 1, Nome = "Mario Monteiro"}
};



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

    //var retorno = await context.Remedios.ToListAsync();
    await context.Remedios.ToListAsync()

);

app.MapGet("/remedios/{id}", async (RemediosDbContext context,int id) =>

    await context.Remedios.FindAsync(id) is Remedios remedio?
        Results.Ok(remedio) : Results.NotFound("Remédio não encontrado.")
);

//  var remedio = await context.Remedios.FindAsync(id);

// remedio = remedios.Find(r => r.Id == id);

//  if(remedios == null)
// {
//     return Results.NotFound("Remédio: " + remedio.Nome + "(" + remedio.Id + ")" + "não encontrado.");
//}

// return Results.Ok(remedio);

app.MapPost("/post", async (RemediosDbContext context, Remedios remedio) => {


    if (remedio != null && remedio.Nome != "")
    {
        context.Remedios.Add(remedio);
        await context.SaveChangesAsync();
        //return Results.Ok(await context.Remedios.ToListAsync());
        return Results.Created($"/post/{remedio.Id}", remedio);
    }

    return Results.BadRequest("Nome não digitado ou está em branco.");
});
app.MapPost("/upload", async (IFormFile file) =>
{
    var tempFile = Path.GetTempFileName();
    app.Logger.LogInformation(tempFile);
    using var stream = File.OpenWrite(tempFile);
    await file.CopyToAsync(stream);
});

app.MapPost("/upload_many", async (IFormFileCollection myFiles) =>
{
    foreach (var file in myFiles)
    {
        var tempFile = Path.GetTempFileName();
        app.Logger.LogInformation(tempFile);
        using var stream = File.OpenWrite(tempFile);
        await file.CopyToAsync(stream);
    }
});

/*


 * 
 * 
 * 
app.MapPost("/post", async (RemediosDbContext context, Remedios remedio) => {

    context.Remedios.Add(remedio);
    await context.SaveChangesAsync();
    return Results.Ok(await context.Remedios.ToListAsync());

    //return Results.NotFound("nao postado");
});

app.MapPost($"/remedios/", async (DbContext RemediosDbContext, Remedios remedio) =>
{


    if (remedio != null)
    {

        await RemediosDbContext.AddAsync(remedio);
        await RemediosDbContext.SaveChangesAsync();
        //return Results.Ok("Remedio cadastrado com sucesso + remedio: " + remedio.Nome);


        //await RemediosDbContext.AddAsync(remedio);
        //await RemediosDbContext.SaveChangesAsync();
        return Results.Created($"/remedios/{remedio.Id}", remedio);
    }
    else
    {
        return Results.BadRequest("Remedio não encontrado");
    }

    // await db.Students.AddAsync(student);
    // await db.SaveChangesAsync();

});


*/



/*





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
*/
app.MapPut("/update/{id}", async (RemediosDbContext context , Remedios RemediosAtualiza, int id) =>
{
    //RemediosAtualiza.Id = id;
    var remedio = await context.Remedios.FindAsync(id);
        
    //remedios.Find(r => r.Id == id);


    if(remedio is null && remedio.Nome != "")
    {
        return Results.NotFound("Remédio: " + remedio.Nome + "não encontrado.");
    }

    remedio.Id = RemediosAtualiza.Id;
    remedio.Nome = RemediosAtualiza.Nome;
    remedio.Link_Bula = RemediosAtualiza.Link_Bula;

    await context.SaveChangesAsync();

    return Results.Created($"/update/{remedio.Id}", remedio);
    //return Results.Ok(remedio);

});

app.MapDelete("/delete/{id}", async (RemediosDbContext context  , int id) =>
{
    var remedio = await context.Remedios.FindAsync(id);

    if (remedio is null)
    {
        return Results.NotFound("Nao existe esse remedio de id: " + id);
    }

    context.Remedios.Remove(remedio);
    //remedio.Remove(remedio);
    await context.SaveChangesAsync();
    return Results.Created($"/delete/{remedio.Id}", remedio);
});













app.Run();



