using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Mapster;
using UOW.BusinessLayer.Dependency;
using UOW.DataAccessLayer.EntityFramework;
using UOW.DataAccessLayer.EntityFramework.UnitOfWork.Abstract;
using UOW.DataAccessLayer.EntityFramework.UnitOfWork.Concrete;
using UOW.WebAPI.Mapping;

var builder = WebApplication.CreateBuilder(args);

#region DbContext
builder.Services.AddDbContext<ApplicationContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("ConnStr")));
#endregion

#region Mapster
var config = TypeAdapterConfig.GlobalSettings;
config.Scan(Assembly.GetExecutingAssembly());
#endregion

#region DataAccess Register
builder.Services.AddScoped<IUnitOfWork, EFUnitOfWork>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
#endregion

#region Business Register
builder.Services.Scan(scan => scan.FromAssemblyOf<IScopedDependency>()
                                  .AddClasses(x => x.Where(y => y.Name.EndsWith("Service")))
                                  .AsImplementedInterfaces()
                                  .WithScopedLifetime());
#endregion
// Add services to the container.

builder.Services.AddControllers();
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

app.UseAuthorization();

app.MapControllers();

app.Run();
