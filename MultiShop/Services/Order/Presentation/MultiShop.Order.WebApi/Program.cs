using MultiShop.Order.Application.Features.CQRS.Handlers.AddressHandlers;
using MultiShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers;
using Microsoft.Extensions.DependencyInjection;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Application.Services;
using MultiShop.Order.Persistence.Context;
using MultiShop.Order.Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Veritabaný baðlamýný ekleme
builder.Services.AddDbContext<OrderContext>();

// IRepository ve Repository baðýmlýlýklarýný ekleme
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

// Application service ekleme
builder.Services.AddApplicationService(builder.Configuration);

// CQRS Handler'larýný ekleme (Address ve Order Detail)
#region Address Handlers
builder.Services.AddScoped<GetAddressQueryHandler>();
builder.Services.AddScoped<GetAddressByIdQueryHandler>();
builder.Services.AddScoped<CreateAddressCommandHandler>();
builder.Services.AddScoped<UpdateAddressCommandHandler>();
builder.Services.AddScoped<RemoveAddressCommandHandler>();
#endregion

#region OrderDetail Handlers
builder.Services.AddScoped<GetOrderDetailQueryHandler>();
builder.Services.AddScoped<GetOrderDetailByIdQueryHandler>();
builder.Services.AddScoped<CreateOrderDetailCommandHandler>();
builder.Services.AddScoped<UpdateOrderDetailCommandHandler>();
builder.Services.AddScoped<RemoveOrderDetailCommandHandler>();
#endregion

// Controllers ve Newtonsoft.Json için yapýlandýrma
builder.Services.AddControllers()
    .AddNewtonsoftJson(options =>
        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

// Swagger ayarlarý
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Geliþtirme ortamý için Swagger yapýlandýrmasý
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// HTTPS yönlendirme ve yetkilendirme
app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();
app.Run();
