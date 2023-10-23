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

        public async Task<UserSessionEntity> GetItemAsync(int id)
        {
            await Init();
            return await Database.Table<UserSessionEntity>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<UserSessionEntity>> GetItemsAsync()
        {
            await Init();
            return await Database.Table<UserSessionEntity>().ToListAsync();
        }

        public async Task<int> SaveItemAsync(UserSessionEntity item)
        {
            await Init();
            return await Database.InsertAsync(item);
        }

        public async Task<int> DeleteAllItemsAsync()
        {
            await Init();
            if (await Database.Table<UserSessionEntity>().CountAsync() > 0)
            return await Database.DeleteAllAsync<UserSessionEntity>();
            else 
                return 0;
        }
    }
}
