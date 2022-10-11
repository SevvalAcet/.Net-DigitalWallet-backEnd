using Business.Abstarct;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Digiwallet.Business.Concrete;
using Digiwallet.Businness.Abstarct;
using Digiwallet.DataAccess.Abstract;
using Digiwallet.DataAccess.Concrete;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<ILastTransactionService, LastTransactionManager>();
builder.Services.AddTransient<ILastTranactionRepository, LastTransactionRepository>();
builder.Services.AddTransient<IUserService, UserManager>();
builder.Services.AddTransient<IUserRepository, UserRepository>();



builder.Services.AddCors(options =>
{
    options.AddPolicy(
        "AllowOrigin",
        builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors("AllowOrigin");
app.Run();

