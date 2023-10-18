using SQLite;
using TaxiApp.Const;
using TaxiApp.Entity.Users;

namespace TaxiApp
{
    internal class UserSessionInfoItemDatabase
    {
        SQLiteAsyncConnection Database;

        public UserSessionInfoItemDatabase()
        {
        }

        async Task Init()
        {
            if (Database is not null)
                return;

            Database = new SQLiteAsyncConnection(SQLiteDBConnectin.DatabasePath, SQLiteDBConnectin.Flags);
            var result = await Database.CreateTableAsync<UserSessionEntity>();
        }

        public async Task<TodoItem> GetItemAsync(int id)
        {
            await Init();
            return await Database.Table<TodoItem>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public async Task<int> SaveItemAsync(UserSessionEntity item)
        {
            await Init();
            return await Database.InsertAsync(item);
        }

        public async Task<int> DeleteItemAsync(UserSessionEntity item)
        {
            await Init();
            return await Database.DeleteAsync(item);
        }
    }
}
