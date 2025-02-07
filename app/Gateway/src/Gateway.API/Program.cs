using Common.Models.Serialization;
using Gateway.Services;

var builder = WebApplication.CreateBuilder(args);

/*builder.Services.AddSwaggerGen(options =>
{
    var basePath = AppContext.BaseDirectory;
    var xmlPath = Path.Combine(basePath, "Gateway.API.xml");
    options.IncludeXmlComments(xmlPath);
});*/

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        corsBuilder => corsBuilder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddHttpClient();

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new DateOnlyJsonConverter());
    });

builder.Services.AddTransient<ILibraryService, LibraryService>(provider =>
{
    var clientFactory = provider.GetRequiredService<IHttpClientFactory>();
    return new LibraryService(clientFactory, builder.Configuration.GetConnectionString("LibraryService"));
});

builder.Services.AddTransient<IReservationService, ReservationService>(provider =>
{
    var clientFactory = provider.GetRequiredService<IHttpClientFactory>();
    return new ReservationService(clientFactory, builder.Configuration.GetConnectionString("ReservationService"));
});

builder.Services.AddTransient<IRatingService, RatingService>(provider =>
{
    var clientFactory = provider.GetRequiredService<IHttpClientFactory>();
    return new RatingService(clientFactory, builder.Configuration.GetConnectionString("RatingService"));
});

var app = builder.Build();

/*if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}*/

app.UseHttpsRedirection();
app.MapControllers();

app.UseCors("AllowAllOrigins");

app.Run();