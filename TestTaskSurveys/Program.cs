using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TestTaskSurveys.Data;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddDbContext<SurveysDbContext>(options =>
                options.UseNpgsql(builder.Configuration.GetConnectionString("DbConnection")));

        builder.Services.AddMediatR(opt => opt.RegisterServicesFromAssembly(typeof(Program).Assembly));



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

        MigrateDb(app);

        app.Run();
    }
    static void MigrateDb(IApplicationBuilder app)
    {
        var scopeFactory = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>();

        using var scope = scopeFactory.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<SurveysDbContext>();
        dbContext.Database.Migrate();
    }
}