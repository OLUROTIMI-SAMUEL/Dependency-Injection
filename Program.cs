using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using DependencyInjectionDemo.Logic;
using Serilog;

// for our createBuider many things come from it Our Logging, set up out Deoendency Container, It Set Up Our configuration
// for talking to appsetting.Json 
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// service configuration is where we do our dependency Injection builder.Services here means dependency injection. The first to method add as lot of 
// services because they help run the program. 
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
//this add demo logic to our services. This means we can ask for it when ever we need it 
//AddTransient here here mean everytime we ask for the item "DemoLogic" we get a new instance this is the most common method to create a new instance.
// Although we have the AddSingleton this will create an instance of a class that get the same instance every single time.i.e it create an 
//instance Once and we use it through out the entire application. Also be care full not to over use singleton.
// We also have the AddScoped this is a Singleton Per Person, this is because when you copy the URL in another tab the value changes so therefore a
//new instance of the class "DemoLogic" is generated when we open a new Tab. or for standard it happens when we have one instance Per Connection To
//The Server.
builder.Services.AddTransient<IDemoLogic, DemoLogic>();
// All what the code above is saying is when we ask for IDemologic give us DemoLogic. We are making use of Interface with our dependency because it 
//very easy for us to remove dependencies when we are doing Unit-Testing. So it is important for us to always use interface with our dependency
//injection 


//This is not builder.service but this helps us to tell our program that dont use the default logger from ASP .NET Core instead use Serilog,
//mean this override the default logger of our program with serilog instead. 
builder.Host.UseSerilog((context, config) =>
{
    config.WriteTo.Console();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
