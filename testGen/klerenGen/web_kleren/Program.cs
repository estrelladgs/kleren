

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddHttpContextAccessor();

builder.Services.AddDistributedMemoryCache();


builder.Services.AddControllersWithViews();

builder.Services.AddSession(options =>

{
    options.Cookie.Name = ".User.Session";

    options.IdleTimeout = TimeSpan.FromSeconds(1000);

    options.Cookie.HttpOnly = true;
    
    options.Cookie.IsEssential = true;

});

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

app.UseSession();

app.UseAuthorization();

/*app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");*/
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Articulo}/{action=Home}/{id?}");
   //pattern: "{controller=Articulo}/{action=Index}/{id?}");


app.Run();
