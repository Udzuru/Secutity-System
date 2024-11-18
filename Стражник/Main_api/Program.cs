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

��������Context db = new ��������Context();

app.MapGet("/User/Check", () =>
{
    var k = db.������������s.Where(p=>p.Check==false || p.����������==null || p.��������==null || p.������==null).ToArray();
    if (k == null) return Results.NotFound();
    return Results.Json(k, options);
});
app.MapPost("/Users", (SendData datas) =>
{
    var data = datas.Pep;
    Console.WriteLine(data.Length);
    foreach(var dataItem in data)
    {
        var k = db.������������s.Where(p => p.Id == dataItem.Id).FirstOrDefault();
        if (dataItem.Check != null)
        {
            k.Check = dataItem.Check;
        }
        if (dataItem.����� != null)
        {
            k.����� = dataItem.�����;
        }
        if (dataItem.��������������� != null)
        {
            k.��������������� = dataItem.���������������;
        }
        if (dataItem.������ != null)
        {
            k.������ = dataItem.������;
        }
        if (dataItem.�������������� != null)
        {
            k.�������������� = dataItem.��������������;
        }
        if (dataItem.���������� != null)
        {
            k.���������� = dataItem.����������;
        }
        if (dataItem.�������� != null)
        {
            k.�������� = dataItem.��������;
        }
        if (dataItem.������ != null)
        {
            k.������ = dataItem.������;
        }


        db.SaveChanges();
    }
    return Results.Ok();
});
app.MapGet("/Types", () =>
{
    var k = db.���������������s.ToList();
    if (k == null) return Results.NotFound();
    return Results.Json(k,options);
});
app.MapGet("/Dolgnosty", () =>
{
    var k = db.���������s.ToList();
    if (k == null) return Results.NotFound();
    return Results.Json(k, options);
});
app.MapGet("/User/{Login}/{Password}/{SecretCode}/{Type}", (string Login,string Password,string SecretCode,int Type) =>
{
    var k = db.������������s.Where(p => p.����� == Login && p.������ == Password && p.�������������� == SecretCode && p.��������������� == Type).FirstOrDefault();
    if (k == null) return Results.NotFound();
    return Results.Json(k, options);
});
app.MapPost("/User", (������������ polt) =>
{
    var k = db.������������s.Add(polt);
    db.SaveChanges();

});

app.MapGet("/", () => "������ �������� ������ ;) !");
app.Run();
class SendData
{
    public ������������[] Pep { get; set; }
}