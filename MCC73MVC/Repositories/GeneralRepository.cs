using MCC73MVC.Contexts;
using MCC73MVC.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace MCC73MVC.Repositories;

public class GeneralRepository<Entity, T> : IRepository<Entity, T> where Entity : class
{
    private readonly MyContext _context;
    private readonly DbSet<Entity> _entities;

    public GeneralRepository(MyContext context)
    {
        _context = context;
        _entities = context.Set<Entity>();
    }

    public IEnumerable<Entity> Get()
    {
        return _entities.ToList();

    }

    public Entity Get(T id)
    {
        return _entities.Find(id);
    }

    public int Insert(Entity entity)
    {
        _entities.Add(entity);
        var result = _context.SaveChanges(); //simpan pada database
        return result;
    }

    public int Update(Entity entity)
    {

        _entities.Entry(entity).State = EntityState.Modified; // EntityState.Modified merubah state yang tersimpan.
        var result = _context.SaveChanges();// seperti sql commit
        return result;

    }

    public int Delete(T id)
    {
        var data = _entities.Find(id);
        if (data == null)
        {
            return 0;
        }
        _entities.Remove(data);
        var result = _context.SaveChanges();
        return result;

    }
}
