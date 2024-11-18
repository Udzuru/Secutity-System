using Main_api;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Net.WebSockets;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<JsonOptions>(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    options.JsonSerializerOptions.WriteIndented = true;
});
var options = new JsonSerializerOptions(JsonSerializerDefaults.Web)
{
    ReferenceHandler = ReferenceHandler.IgnoreCycles,
    WriteIndented = true
};
var app = builder.Build();

СтражникContext db = new СтражникContext();

app.MapGet("/User/Check", () =>
{
    var k = db.Пользователиs.Where(p=>p.Check==false || p.Добавление==null || p.Просмотр==null || p.Отчеты==null).ToArray();
    if (k == null) return Results.NotFound();
    return Results.Json(k, options);
});
app.MapPost("/Users", (SendData datas) =>
{
    var data = datas.Pep;
    Console.WriteLine(data.Length);
    foreach(var dataItem in data)
    {
        var k = db.Пользователиs.Where(p => p.Id == dataItem.Id).FirstOrDefault();
        if (dataItem.Check != null)
        {
            k.Check = dataItem.Check;
        }
        if (dataItem.Логин != null)
        {
            k.Логин = dataItem.Логин;
        }
        if (dataItem.ТипПользователя != null)
        {
            k.ТипПользователя = dataItem.ТипПользователя;
        }
        if (dataItem.Пароль != null)
        {
            k.Пароль = dataItem.Пароль;
        }
        if (dataItem.СекретноеСлово != null)
        {
            k.СекретноеСлово = dataItem.СекретноеСлово;
        }
        if (dataItem.Добавление != null)
        {
            k.Добавление = dataItem.Добавление;
        }
        if (dataItem.Просмотр != null)
        {
            k.Просмотр = dataItem.Просмотр;
        }
        if (dataItem.Отчеты != null)
        {
            k.Отчеты = dataItem.Отчеты;
        }


        db.SaveChanges();
    }
    return Results.Ok();
});
app.MapGet("/Types", () =>
{
    var k = db.ТипПользователяs.ToList();
    if (k == null) return Results.NotFound();
    return Results.Json(k,options);
});
app.MapGet("/Dolgnosty", () =>
{
    var k = db.Должностьs.ToList();
    if (k == null) return Results.NotFound();
    return Results.Json(k, options);
});
app.MapGet("/User/{Login}/{Password}/{SecretCode}/{Type}", (string Login,string Password,string SecretCode,int Type) =>
{
    var k = db.Пользователиs.Where(p => p.Логин == Login && p.Пароль == Password && p.СекретноеСлово == SecretCode && p.ТипПользователя == Type).FirstOrDefault();
    if (k == null) return Results.NotFound();
    return Results.Json(k, options);
});
app.MapPost("/User", (Пользователи polt) =>
{
    var k = db.Пользователиs.Add(polt);
    db.SaveChanges();

});

app.MapGet("/", () => "Сервер работает хорошо ;) !");
app.Run();
class SendData
{
    public Пользователи[] Pep { get; set; }
}