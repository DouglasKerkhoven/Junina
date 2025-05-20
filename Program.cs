
using curitibano.microservico.junina.Infra;
using curitibano.microservico.junina.Infra.Repository;

using Microsoft.EntityFrameworkCore;
using AutoMapper;
using curitibano.microservicos.junina.DTOs.Mapeamento;
namespace curitibano.microservico.junina
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var mapperConfig = new MapperConfiguration(mc => { mc.AddProfile(new MappingProfile()); });
            IMapper mapper = mapperConfig.CreateMapper();
            builder.Services.AddSingleton(mapper);
            builder.Services.AddSignalR();
            // Add services to the container.

            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));



            builder.Services.AddDbContext<JuninaDbContext>(options =>
            options.UseSqlite("Data Source=itens.db"));

            builder.Services.AddScoped<ItemRepository>();
            builder.Services.AddScoped<VendaRepository>();


            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

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
        }
    }
}
