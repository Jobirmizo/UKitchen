using System.Runtime.InteropServices;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using UKitchen.Domain.Data.Dto.ExcelDto;
using UniversityKitchen.Data.Context;
using UniversityKitchen.Data.Enum;
using UniversityKitchen.Exception;

namespace UniversityKitchen.Features.ImportFile;

public class ExcelService(AppDbContext _context, IMapper _mapper) : IExcelService
{
    public async Task<List<MealExcelDto>> ReadExcelFileAsync(IFormFile file)
    {
        ExcelPackage.LicenseContext = LicenseContext.NonCommercial; 
        var result = new List<MealExcelDto>();

        using (var stream = new MemoryStream())
        {
            await file.CopyToAsync(stream);
            using (var package = new ExcelPackage(stream))
            {
                ExcelWorksheet? sheet = package.Workbook.Worksheets.FirstOrDefault();

                if (sheet == null)
                    throw new NotFoundMannually("any data found in the workbook");

                int rowCount = sheet.Dimension.Rows;
                for (int row = 2; row <= rowCount; row++)
                {
                    var mealDto = new MealExcelDto
                    {
                        Name = sheet.Cells[row, 1].Text,
                        Quantity = int.TryParse(sheet.Cells[row, 2].Text, out var quantity) ? quantity : 0,
                        Status = sheet.Cells[row, 3].Text.Trim().ToLower() switch
                        {
                            "true" => true,
                            "1" => true,
                            "false" => false,
                            "0" => false,
                            _ => false // Default to false if invalid input
                        },
                        MealCategoryEnum = int.TryParse(sheet.Cells[row, 4].Text, out var mealCategory)
                            ? mealCategory
                            : 0,
                        GivenPrice = double.TryParse(sheet.Cells[row, 5].Text, out var price) ? price : 0
                    };

                    result.Add(mealDto);
                }
            }
        }
        
        return result;
    }
}