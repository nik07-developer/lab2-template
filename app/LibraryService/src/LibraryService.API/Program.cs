using LibraryService.Storage.DbContexts;
using LibraryService.Storage.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
    
/*builder.Services.AddSwaggerGen(options =>
{
    var basePath = AppContext.BaseDirectory;
    var xmlPath = Path.Combine(basePath, "LibraryService.API.xml");
    options.IncludeXmlComments(xmlPath);
});*/

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();

builder.Services.AddDbContext<PostgresContext>(
    options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
);

builder.Services.AddTransient<ILibrariesRepository, LibrariesRepository>();
builder.Services.AddTransient<IBooksRepository, BooksRepository>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<PostgresContext>();
    dbContext.Database.Migrate();
}

/*if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}*/

app.UseHttpsRedirection();
app.MapControllers();

app.Run();