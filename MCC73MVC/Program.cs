using MCC73MVC.Contexts;
using MCC73MVC.Repositories.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);


//Injection
builder.Services.AddScoped<DivisionRepositories>();
builder.Services.AddScoped<AccountRepositories>();
builder.Services.AddScoped<EmployeeRepositories>();
builder.Services.AddScoped<DepartmentRepositories>();
builder.Services.AddScoped<RoleRepositories>();
builder.Services.AddScoped<AccountRoleRepositories>();


// ini adalah konfigurasi untuk menghubungkan MyContext ke Sql Server.
builder.Services.AddDbContext<MyContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("Connection")));

//Configurasi JWT
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(option =>
    {
        option.RequireHttpsMetadata = false;
        option.SaveToken = true;
        option.TokenValidationParameters = new TokenValidationParameters()
        {

            ValidateAudience = false,
            //Usually, this your application base URL
            //ValidAudience = builder.Configuration["JWT:Audience"],
            ValidateIssuer = false,
            //If the JWT is created using a web service, then this would be the consumer URL.
            //ValidIssuer = builder.Configuration["JWT:Issuer"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:key"])),
            ValidateLifetime = true,
            ClockSkew = TimeSpan.Zero
        };
    });

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
