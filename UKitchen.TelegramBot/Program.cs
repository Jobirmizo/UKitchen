using Microsoft.EntityFrameworkCore;
using Telegram.Bot;
using Telegram.Bot.Polling;
using UKitchen.TelegramBot.Features.MealService;
using UKitchen.TelegramBot.Services;
using UniversityKitchen.Data.Context;

var builder = WebApplication.CreateBuilder(args);
var token= builder.Configuration.GetValue<string>("BotToken", string.Empty);

builder.Services.AddOpenApi();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("Connection")));
builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddScoped<IMealService, MealService>();
builder.Services.AddSingleton(p => new TelegramBotClient(token));
builder.Services.AddSingleton<IUpdateHandler, BotUpdateHandler>();
builder.Services.AddHostedService<BotBackgroundService>();

var app = builder.Build();

var supportedCultures = new[] { "uz-UZ", "en-US", "ru-RU" };
var localizationOptions = new RequestLocalizationOptions().SetDefaultCulture(supportedCultures[0])
    .AddSupportedCultures(supportedCultures)
    .AddSupportedUICultures(supportedCultures);

app.UseRequestLocalization(localizationOptions);

app.Run();
