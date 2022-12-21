using SwaggerDateFormat;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddSwaggerGen(options =>
{
    // add a custom operation filter which sets default values
    options.OperationFilter<SwaggerDefaultValues>();
    
    var fileName = typeof( Program ).Assembly.GetName().Name + ".xml";
    var filePath = Path.Combine( AppContext.BaseDirectory, fileName );

    // integrate xml comments
    options.IncludeXmlComments( filePath );
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
