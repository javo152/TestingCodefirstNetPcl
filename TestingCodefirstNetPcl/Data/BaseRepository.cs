using SQLite;
using System.Linq.Expressions;
using TestingCodefirstNetPcl.Framework;
using TestingCodefirstNetPcl.Models;

namespace TestingCodefirstNetPcl.Data;

public class BaseRepository<T> where T : class, IEntity, new()
{
    private readonly DatabaseContext _dbContext;

    public BaseRepository(DatabaseContext dbContext)
    {
        _dbContext = dbContext;
    }

    protected SQLiteAsyncConnection Connection => _dbContext.Connection;

    public Task<List<T>> GetAllAsync()
    {
        return Connection.Table<T>().ToListAsync();
    }

    public Task<List<T>> GetAllAsync(Expression<Func<T, bool>> predicate)
    {
        return Connection.Table<T>().Where(predicate).ToListAsync();
    }

    public Task<T?> GetByIdAsync(int id)
    {
        return Connection.FindAsync<T>(id);
    }

    public async Task<int> SaveAsync(T item)
    {
        if (item.Id != 0)
            return await Connection.UpdateAsync(item);
        else
            return await Connection.InsertAsync(item);
    }

    public async Task<int> SaveAsync(IEnumerable<T> items)
    {
        var itemsToInsert = new List<T>();
        var itemsToUpdate = new List<T>();

        foreach (var item in items)
        {
            if (item.Id != 0)
                itemsToUpdate.Add(item);
            else
                itemsToInsert.Add(item);
        }

        var count = 0;

        if (itemsToInsert.Count > 0)
            count += await Connection.InsertAllAsync(itemsToInsert);

        if (itemsToUpdate.Count > 0)
            count += await Connection.UpdateAllAsync(itemsToUpdate);

        return count;
    }

    public Task<int> InsertAllAsync(IEnumerable<T> items)
    {
        return Connection.InsertAllAsync(items);
    }

    public Task<int> UpdateAllAsync(IEnumerable<T> items)
    {
        return Connection.UpdateAllAsync(items);
    }

    public Task<int> DeleteAsync(T item)
    {
        return Connection.DeleteAsync(item);
    }
}
