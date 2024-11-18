using Main_api;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
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






ProBdContext db = new ProBdContext();
app.MapGet("/users/reg/{Login}/{Password}", (string Login,string Password) =>
{
    var k = db.Users.Where(p=>p.Login == Login && p.Password == Password).FirstOrDefault();
    if (k == null) return Results.NotFound(new { message = "Пользователь не найден" });

    // если пользователь найден, отправляем его
    return Results.Json(k);
});
app.MapPost("/users/reg/", (User user) =>
{   
    db.Users.Add(user);
    Console.WriteLine(user.Name);
    db.SaveChanges();
});
app.MapGet("/employe/reg/{Code}", (string Code ) =>
{
    int code =Convert.ToInt32(Code);
    Console.WriteLine(Code);

    var k = db.Employers.Where(p => p.Code == code).FirstOrDefault();
    if (k == null) return Results.NotFound(new { message = "Пользователь не найден" });

    // если пользователь найден, отправляем его
    return Results.Json(k);
});
app.MapGet("/Otdel/{Code}", (string Code) =>
{
    int temp_int = Convert.ToInt32(Code);
    var k = db.Employers.Where(p => p.Code == temp_int).FirstOrDefault();

    if (k == null) return Results.NotFound(new { message = "Пользователь не найден" });

    // если пользователь найден, отправляем его
    return Results.Json(k,options);
});
app.MapGet("/Zaivki", () =>
{
    var k = db.Zaivkis.ToList();
    if (k == null) return Results.NotFound(new { message = "Пользователь не найден" });

    // если пользователь найден, отправляем его
    return Results.Json(k,options);
});
app.MapGet("/Zaivki/People/{id}", (string id) =>
{
    int Id = Convert.ToInt32(id);
    var k = db.Zaivkis.Where(p => p.People == Id).ToList();
    if (k == null) return Results.NotFound(new { message = "Пользователь не найден" });

    // если пользователь найден, отправляем его
    return Results.Json(k, options);
});
app.MapGet("/Zaivki/People/Name/{name}/{email}", (string name,string email) =>
{
    var k = db.People.Where(p => p.Name == name && p.EMail == email ).FirstOrDefault().Zaivkis;
    if (k == null) return Results.NotFound(new { message = "Пользователь не найден" });

    // если пользователь найден, отправляем его
    return Results.Json(k, options);
});
app.MapGet("/Zaivki/{id}", (string id) =>
{
    int Id = Convert.ToInt32(id);
    var k = db.Zaivkis.Where(p=>p.Id == Id).FirstOrDefault();
    if (k == null) return Results.NotFound(new { message = "Пользователь не найден" });

    // если пользователь найден, отправляем его
    return Results.Json(k, options);
});
app.MapGet("/Types", () =>
{
    var k = db.Typs.ToList();
    if (k == null) return Results.NotFound(new { message = "Пользователь не найден" });

    // если пользователь найден, отправляем его
    return Results.Json(k,options);
});
app.MapGet("/Types/{id}", (string id) =>
{
    int Id = Convert.ToInt32(id);
    var k = db.Typs.Where(p=>p.Id == Id).FirstOrDefault();
    if (k == null) return Results.NotFound(new { message = "Пользователь не найден" });

    // если пользователь найден, отправляем его
    return Results.Json(k, options);
});
app.MapGet("/Employe", () =>
{   
    var k = db.Employers.ToList();
    if (k == null) return Results.NotFound(new { message = "Пользователь не найден" });

    // если пользователь найден, отправляем его
    return Results.Json(k, options);
});

app.MapGet("/Zaivki/{type}/{where}/{status}", (string type,string where,string status) =>
{
    var res = db.Zaivkis.ToList();
    int ttype = Convert.ToInt32(type);
    int wwhere = Convert.ToInt32(where);
    if (type != "0")
    {

        res = res.Where(p => p.Type == ttype).ToList();
    }
    if(where != "0")
    {
        res = res.Where(p => p.Where == wwhere).ToList();
    }
    if (status != "0")
    {
        res = res.Where(p => p.Status == status).ToList();
    }
    if (res == null) return Results.NotFound(new { message = "Пользователь не найден" });

    // если пользователь найден, отправляем его
    return Results.Json(res,options);
});
app.MapPut("/Clients/", (Person person) =>
{
    var k = db.People.Where(p => p.Id == person.Id).FirstOrDefault();
    k.Blacklist = true;
    db.SaveChanges();
});
app.MapGet("/Clients/{id}", (string id) =>
{
    int pik = Convert.ToInt32(id);
    var k = db.People.Where(p=>p.Id == pik).FirstOrDefault();
    if (k == null) return Results.NotFound(new { message = "Пользователь не найден" });

    // если пользователь найден, отправляем его
    return Results.Json(k,options);
});
app.MapGet("/Find/{find}", (string find) =>
{
    List<Zaivki> zaivkis = new List<Zaivki>();
    var p = db.People.Where(k=> k.Name == find).FirstOrDefault();
    var e = db.People.Where(k => k.Surname == find).FirstOrDefault();
    var r = db.People.Where(k => k.Patronimic == find).FirstOrDefault();
    if (p != null)
    {
        zaivkis.AddRange(db.Zaivkis.Where(t => t.People == p.Id).ToArray());
    }
    if (e != null)
    {
        zaivkis.AddRange(db.Zaivkis.Where(t => t.People == e.Id).ToArray());
    }
    if (r != null)
    {
        zaivkis.AddRange(db.Zaivkis.Where(t => t.People == r.Id).ToArray());
    }
    return Results.Json(zaivkis, options);
});
app.MapGet("/Clients/email/{email}", (string email) =>
{
    var k = db.People.Where(p => p.EMail == email).FirstOrDefault();
    if (k == null) return Results.NotFound(new { message = "Пользователь не найден" });

    // если пользователь найден, отправляем его
    return Results.Json(k, options);
});
app.MapPost("/Clients" , (Person p) =>{
    var k = db.People.Where(k => k.PassportSeria + k.PassportNumber == p.PassportSeria + p.PassportNumber).FirstOrDefault(); ;
    if (k == null)
    {
        db.People.Add(p);
        db.SaveChanges();
    }
    else
    {
        var usv = db.People.Where(t => t.Id == k.Id).FirstOrDefault();
        usv.EMail = p.EMail;
        db.SaveChanges();
        p = k;
    }
    
    return Results.Json(p.Id,options);


});
app.MapPost("/Zaivki", (Zaivki p) => {
    db.Zaivkis.Add(p);
    db.SaveChanges();
    return Results.Json(p.Id, options);


});
app.MapPost("/Zaivki/edit", (Zaivki p) => {
    var p_edit=db.Zaivkis.Where(k => k.Id == p.Id).FirstOrDefault();
    p_edit.Status = p.Status;
    p_edit.Date = p.Date;
    db.SaveChanges();
    return Results.Json(p.Id, options);


});
app.MapPost("/Time/Start/", (Person peopl) =>
{
    
    db.Times.Add(new Time {TimeSt=DateTime.Now,PeopleId=peopl.Id });
    
    db.SaveChanges();
    return Results.Json(peopl, options);
});
app.MapPut("/Time/End/", (Time peopl) =>
{

    var k = db.Times.Where(t=>t.PeopleId == peopl.Id).FirstOrDefault();
    k.TimeEnd = peopl.TimeEnd;

    db.SaveChanges();
    return Results.Json(peopl, options);
});
app.MapGet("Times/", () =>
{
    List<Time> times = db.Times.Where(p => p.TimeEnd == null).ToList();
    return Results.Json(times, options);
});
app.MapGet("Times/{id}", (int id) =>
{
    var k = db.Times.Where(p=>p.PeopleId==id && p.TimeEnd==null).FirstOrDefault();

    if (k == null) return Results.NotFound(new { message = "Пользователь не найден" });

    return Results.Json(k, options);
});

app.MapGet("/", () => "Hello World!");
app.Run();
