using Domain.Interfaces.Generics;
using Entities._3___InfraStructure.Infra.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Entities._3___InfraStructure.Infra.Repository.Generics;

public class GenericsRepository<T> : InterfaceGeneric<T> where T : class
{
    private readonly DbContextOptions<ContextBase> _OptionsBuilder;
    
    public GenericsRepository()
    {
        _OptionsBuilder = new DbContextOptions<ContextBase>();
    }
    
    public async Task Add(T Object)
    {
        using (var context = new ContextBase(_OptionsBuilder))
        {
            await context.Set<T>().AddAsync(Object);
            await context.SaveChangesAsync();
        }
    }

    public async Task Update(T Object)
    {
        using (var context = new ContextBase(_OptionsBuilder))
        {
            context.Set<T>().Update(Object);
            await context.SaveChangesAsync();
        }
    }

    public async Task Delete(T Object)
    {
        using (var context = new ContextBase(_OptionsBuilder))
        {
            context.Set<T>().Remove(Object);
            await context.SaveChangesAsync();
        }
    }

    public async Task<T> GetEntityById(int Id)
    {
        using (var context = new ContextBase(_OptionsBuilder))
        {
            return await context.Set<T>().FindAsync(Id);
        }
    }

    public async Task<List<T>> List()
    {
        using (var context = new ContextBase(_OptionsBuilder))
        {
            return await context.Set<T>().AsNoTracking().ToListAsync();
        }
    }
}