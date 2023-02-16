using Api_Remedios.Data;
using Api_Remedios.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<RemediosDbContext>(opt => opt.UseSqlServer(builder.Configuration["ConnectionStrings:DefaaultConnection"]));
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
    new Remedios {Id = 1, Nome ="Novalgina" , Descricao = "Alfa beta gama" , Hora_Cadastro= DateTime.Now ,Link_Bula = ""}

};

app.MapGet("/remedios", () =>
{

    return remedios;
});

app.MapGet("/remedios/{id}", (int id) =>
{
    var remedio = remedios.Find(r => r.Id == id);


    return Results.Json(remedio);
});

app.MapPost($"/remedios/", (Remedios remedio) => 
{


    if(remedio is not null)
    {
        remedios.Add(remedio);
    }


    return Results.Ok(remedios);
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
    remedio.Descricao = RemediosAtualiza.Descricao;
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



