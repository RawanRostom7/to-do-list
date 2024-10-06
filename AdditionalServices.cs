namespace LuftbornCodeTest;

public static class AdditionalServices
{
    public static void RegisteredServices(this WebApplicationBuilder builder)
    {
        // Register Basic services 
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(); 

        builder.RegisterDatabaseService();
        builder.RegisterRepositories();
        builder.RegisterCoreOrgins(); 

    }
    public static void RegisterDatabaseService(this WebApplicationBuilder builder)
    {
        string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
        builder.Services.AddDbContext<ApplicationDbContext>(c =>
                       c.UseSqlServer(connectionString)
                        .EnableDetailedErrors()
                        .EnableSensitiveDataLogging()
                        .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));
    }

    public static void RegisterRepositories(this WebApplicationBuilder builder)
    {
        builder.Services.AddTransient<ITodoListTaskRepository, TodoListTaskRepository>();

        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowAnyOrigin",
               builder => builder.AllowAnyOrigin()
                                 .AllowAnyHeader()
                                 .AllowAnyMethod());
        });
    }

    public static void RegisterCoreOrgins(this WebApplicationBuilder builder)
    {
        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowAnyOrigin",
               builder => builder.AllowAnyOrigin()
                                 .AllowAnyHeader()
                                 .AllowAnyMethod());
        });
    }
}