using Crushy.Data;
using Crushy.Services;
using Crushy.WebSocket;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;
using System.Text.Json.Serialization;
using Microsoft.OpenApi.Models;

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

		// SignalR için JWT doğrulama ayarları
		options.Events = new JwtBearerEvents
		{
			OnMessageReceived = context =>
			{
				var accessToken = context.Request.Query["access_token"];
				var path = context.HttpContext.Request.Path;

				if (!string.IsNullOrEmpty(accessToken) && path.StartsWithSegments("/chathub"))
				{
					context.Token = accessToken;
				}
				return Task.CompletedTask;
			}
		};
	});



// CORS Servisin
builder.Services.AddCors(options =>
{
	options.AddPolicy("AllowLocalhost", policy =>
	{

		policy.WithOrigins(
			"http://localhost:5173",
			"https://crushy-backend-g0drd3dvddhjgyhk.canadacentral-01.azurewebsites.net",
			"https://crushy-admin.netlify.app"
		)
		.AllowCredentials()  // Kimlik doğrulama ve cookie gönderimini sağlar
		.AllowAnyHeader() // Herhangi bir başlık (header) kullanmaya izin ver
		.AllowAnyMethod(); // Herhangi bir HTTP metoduna izin ver (GET, POST, vb.)
	});
});


// Add services to the container.
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<EmailService>();
builder.Services.AddScoped<UserProfileService>();
builder.Services.AddScoped<BlockedUserService>();
builder.Services.AddScoped<MessageService>();
builder.Services.AddScoped<AdminService>();
builder.Services.AddScoped<SignalRService>();

// SignalR ekle
builder.Services.AddSignalR();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
	c.SwaggerDoc("v1", new OpenApiInfo
	{
		Title = "Crushy API",
		Version = "v1",
		Description = "Crushy API Documentation"
	});

	// JWT authentication için Swagger UI yapılandırması
	c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
	{
		Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
		Name = "Authorization",
		In = ParameterLocation.Header,
		Type = SecuritySchemeType.ApiKey,
		Scheme = "Bearer"
	});

	c.AddSecurityRequirement(new OpenApiSecurityRequirement
	{
		{
			new OpenApiSecurityScheme
			{
				Reference = new OpenApiReference
				{
					Type = ReferenceType.SecurityScheme,
					Id = "Bearer"
				}
			},
			new string[] {}
		}
	});
});
builder.Services.AddDbContext<ApplicationDbContext>(options =>
	options.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection1")));

builder.Services.AddControllers().AddJsonOptions(options =>
{
	options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
	options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
});
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
app.UseSwagger();
app.UseSwaggerUI(c =>
{
	c.SwaggerEndpoint("/swagger/v1/swagger.json", "Crushy API V1");
	c.RoutePrefix = "swagger";
});
//}

app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseAuthentication(); // Authentication middleware
app.UseAuthorization();

// CORS middleware'ini ekleyin
app.UseCors("AllowLocalhost"); // React frontend uygulamasının originine izin ver

app.MapControllers();

// SignalR Hub'ını ekle
app.MapHub<ChatHub>("/chathub");

app.Run();
