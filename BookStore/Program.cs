using BookStore.Models;
using BookStore.Models.Repositories;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddMvc(options => options.EnableEndpointRouting = false);
builder.Services.AddSingleton<IBooksStoreRepository<Author>,AuthorRepository>();
builder.Services.AddSingleton<IBooksStoreRepository<Book>, BookRepository>();


var app = builder.Build();

//pp.UseMvcWithDefaultRoute();
app.UseStaticFiles();
app.UseMvc(route => {
    route.MapRoute("default", "{controller=Book}/{action=Index}/{id?}");
});
app.Run();


