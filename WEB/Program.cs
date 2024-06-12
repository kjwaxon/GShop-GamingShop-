using ApplicationCore.Entities.UserEntities.Concrete;
using Autofac;
using Autofac.Core;
using Autofac.Extensions.DependencyInjection;
using DataAccess.Autofac;
using DataAccess.AutoMapper;
using DataAccess.Context;
using DataAccess.Context.IdentityContext;
using DataAccess.FluentValidators.AccountValidators;
using DataAccess.FluentValidators.CategoryValidators;
using DataAccess.FluentValidators.ProductValidators;
using DataAccess.FluentValidators.SubcategoryValidators;
using DataAccess.Services.Concrete;
using DataAccess.Services.Interface;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
            .ConfigureContainer<ContainerBuilder>(builder =>
            {
                builder.RegisterModule(new AutofacBusinessModule());
            });


// Add services to the container.
builder.Services.AddValidatorsFromAssemblyContaining<EditUserValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<ChangePasswordValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<CreateCategoryValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<UpdateCategoryValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<CreateSubcategoryValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<UpdateSubcategoryValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<CreateProductValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<UpdateProductValidator>();
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<ICartRepository, CartRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();


var entityConnection = builder.Configuration.GetConnectionString("EntityConnection");
var identityConnection = builder.Configuration.GetConnectionString("IdentityConnection");

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseNpgsql(entityConnection);
    options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

});

builder.Services.AddDbContext<AppIdentityDbContext>(options =>
{
    options.UseNpgsql(identityConnection);
    options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});
builder.Services.AddIdentity<AppUser, IdentityRole>(x =>
{
    x.SignIn.RequireConfirmedPhoneNumber = false;
    x.SignIn.RequireConfirmedEmail = false;
    x.SignIn.RequireConfirmedAccount = false;
    x.User.RequireUniqueEmail = true;
    x.Password.RequiredLength = 3;
    x.Password.RequiredUniqueChars = 0;
    x.Password.RequireNonAlphanumeric = false;
    x.Password.RequireUppercase = false;
    x.Password.RequireLowercase = false;
    x.Password.RequireDigit = false;
})
    .AddEntityFrameworkStores<AppIdentityDbContext>()
    .AddDefaultTokenProviders();

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
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
