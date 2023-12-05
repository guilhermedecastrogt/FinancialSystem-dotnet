using Domain.Interfaces.ICategory;
using Domain.Interfaces.IServices;
using Entities.Entities;

namespace Domain.Services;

public class CategoryService :ICategoryService
{
    private readonly ICategory _iCategory;
    public CategoryService(ICategory iCategory)
    {
        _iCategory = iCategory;
    }
    
    public async Task AddCategory(Category category)
    {
        var valid = category.PropertyStringValidate(category.Name, "Name");
        if(valid)
            await _iCategory.Add(category);
    }

    public async Task UpdateCategory(Category category)
    {
        var valid = category.PropertyStringValidate(category.Name, "Name");
        if (valid)
            await _iCategory.Update(category);
    }
}