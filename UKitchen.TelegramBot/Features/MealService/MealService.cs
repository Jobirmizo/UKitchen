using AutoMapper;
using Microsoft.EntityFrameworkCore;
using UKitchen.Domain.Data.Dto.Telegram;
using UniversityKitchen.Data.Context;

namespace UKitchen.TelegramBot.Features.MealService;

public class MealService(AppDbContext context, IMapper mapper) : IMealService
{
    private readonly AppDbContext _context = context;
    private readonly IMapper _mapper = mapper;

    public async Task<List<GetMealForTelegram>> GetAll()
    {
        var meals = await _context.Meals.ToListAsync();
        return _mapper.Map<List<GetMealForTelegram>>(meals);
    }
}