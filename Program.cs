var builder = WebApplication.CreateBuilder(args);

builder.RegisteredServices();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();
app.UseCors("AllowAnyOrigin");

ApplicationDbContext applicationDbContext = app.Services.CreateScope()
                                               .ServiceProvider.GetRequiredService<ApplicationDbContext>();
applicationDbContext.Database.Migrate();

app.Run();