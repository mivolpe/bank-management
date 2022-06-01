using RealSupervisor.Handler;
using RealSupervisor.hub;
using RealSupervisor.Interface;
using RealSupervisor.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string uri = builder.Configuration.GetValue<string>("BankAPI");

builder.Services.AddHttpClient();

builder.Services.AddHttpClient("bank_api", client =>
{
    client.BaseAddress = new Uri(uri);
    client.DefaultRequestHeaders.Authorization = null;
});

builder.Services.AddMemoryCache();

// auth API call
builder.Services.AddHttpClient<IBankAuthService, BankAuthService>()
    .ConfigureHttpClient(client => client.BaseAddress = new Uri(uri));

builder.Services.AddHttpClient<IClientLogin, ClientLoginService>()
        .ConfigureHttpClient(client => client.BaseAddress = new Uri(uri));

// payment API call
builder.Services.AddTransient<BankAuthHandler>();
builder.Services.AddHttpClient<IPaymentService, PaymentService>()
    .ConfigureHttpClient(client => client.BaseAddress = new Uri(uri))
    .AddHttpMessageHandler<BankAuthHandler>();

builder.Services.AddHttpClient<IClientService, ClientService>()
    .ConfigureHttpClient(client => client.BaseAddress = new Uri(uri))
    .AddHttpMessageHandler<BankAuthHandler>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AnyOrigin", builder =>
    {
        builder.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

builder.Services.AddSignalR(options => options.EnableDetailedErrors = true);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AnyOrigin");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapHub<PaymentHub>("/hub");

app.Run();


