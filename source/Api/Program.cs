using AlphaCentauri.Application;
using AlphaCentauri.Database;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContextPool<Context>(options => options.UseInMemoryDatabase(nameof(Context)));

builder.Services.Scan(scan => scan.FromAssemblies(typeof(ICustomerService).Assembly, typeof(ICustomerRepository).Assembly).AddClasses().AsMatchingInterface());

builder.Services.AddControllers();

builder.Services.AddSwaggerGen();

var application = builder.Build();

application.UseSwagger();

application.UseSwaggerUI();

application.MapControllers();

application.Run();
