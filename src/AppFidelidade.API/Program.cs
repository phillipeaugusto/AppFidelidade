using AppFidelidade.API.Extensions;
using AppFidelidade.Domain.Constants;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors();
builder.Services.AddControllers();
builder.Services.AddMvc();
builder.Services.ServicesDataBaseInitialization(builder.Configuration);
builder.Services.ServicesInitialization();
builder.Services.ServicesComplementaryInitialization();
builder.Services.AddHealthChecks();

var app = builder.Build();
ServicesDatabaseManagement.MigrationInitialisation(app);

if (app.Environment.IsDevelopment())
    app.UseDeveloperExceptionPage();

app.UseSwagger();
app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", ApplicationConstants.NameApplication); });
app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseHealthChecks("/check");

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();