var builder = WebApplication.CreateBuilder(args);

// Adicione o serviço de CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("PermitirTodos", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNamingPolicy = null; // Usar Pascal Case
        options.JsonSerializerOptions.DictionaryKeyPolicy = null;
    });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var container = NossaLoja.Cadastros.Infra.DependencyInjection.Services.Container.GetContainer();
NossaLoja.Cadastros.Infra.DependencyInjection.Services.DependencyInjectionService.Inicializa(container);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Use a política de CORS configurada
app.UseCors("PermitirTodos");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
