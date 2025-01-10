using ECommerce.API.Data;
using ECommerce.API.Repository;
using ECommerce.API.Service;
<<<<<<< HEAD
using Microsoft.EntityFrameworkCore; 
=======
using Microsoft.EntityFrameworkCore;
>>>>>>> 692af034f5107ebc812835a0b702cb2eb20547ba

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//add dbcontext with connection string
builder.Services.AddDbContext<ECommerceContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ECommerceDB")));

//add service dependencies
<<<<<<< HEAD
builder.Services.AddScoped<IUserService, UserService>(); 
builder.Services.AddScoped<IOrderService, OrderService>(); 
=======
builder.Services.AddScoped<IDepartmentService, DepartmentService>();


//Dependency Inject the proper repositories
builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();


>>>>>>> 692af034f5107ebc812835a0b702cb2eb20547ba

//add repo dependencies
builder.Services.AddScoped<IUserRepository, UserRepository>(); 
builder.Services.AddScoped<IOrderRepository, OrderRepository>(); 

//add controllers
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();
app.UseRouting();
app.MapControllers();
app.Run();

