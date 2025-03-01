using Crushy.Data;
using Crushy.UserService;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

var key = Encoding.UTF8.GetBytes("Bu32ByteUzunAnahtar1234567890123456321"); //  güvenli bir anahtar 
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
	.AddJwtBearer(options =>
	{
		options.TokenValidationParameters = new TokenValidationParameters
		{
			ValidateIssuer = false,
			ValidateAudience = false,
			ValidateLifetime = true,
			ValidateIssuerSigningKey = true,
			IssuerSigningKey = new SymmetricSecurityKey(key)
		};
	});



// CORS Servisin
builder.Services.AddCors(options =>
{
	options.AddPolicy("AllowLocalhost", policy =>
	{
		policy.WithOrigins("http://localhost:5173") 
			  .AllowCredentials()  // Kimlik doðrulama ve cookie gönderimini saðlar
			  .AllowAnyHeader() // Herhangi bir baþlýk (header) kullanmaya izin ver
			  .AllowAnyMethod(); // Herhangi bir HTTP metoduna izin ver (GET, POST, vb.)
	});
});


// Add services to the container.
builder.Services.AddScoped<UserService>(); // UserService'i DI container'a ekle

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
	options.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection")));

builder.Services.AddControllers().AddJsonOptions(options =>
{
	options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
	options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
});
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseAuthentication(); // Authentication middleware
app.UseAuthorization();

// CORS middleware'ini ekleyin
app.UseCors("AllowLocalhost"); // React frontend uygulamasýnýn originine izin ver

app.MapControllers();

app.Run();
