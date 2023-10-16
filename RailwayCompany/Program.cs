using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption;
using System.Net;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using RailwayCompany.Data;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<RailwayRoutesContext>(options =>
    options.UseNpgsql(connectionString));
//builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddControllersWithViews();

var app = builder.Build();


//using (RailwayRoutesContext db = new RailwayRoutesContext()) {
//    var trs = (from t in db.Trains
//               where t.TrainComfort == false
//               select t).ToList();

//    var long_stop = (from s in db.Stations
//                     where s.StationWaitingtime > 5
//                     orderby s
//                     select s).ToList();

//    foreach (var t in trs)
//        Console.WriteLine($"{t.TrainId} - {t.TrainPriretyqoef }");

//    Console.WriteLine("Station with long stops:");

//    foreach (var s in long_stop)
//        Console.WriteLine($"{s.StationName} - {s.StationRoute}");
//}


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

