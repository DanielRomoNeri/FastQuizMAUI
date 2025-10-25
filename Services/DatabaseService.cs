using FastQuizMAUI.Models;
using SQLite;

namespace FastQuizMAUI.Services
{
    public class DatabaseService
    {
        private readonly SQLiteAsyncConnection _database;
        public DatabaseService()
        {
            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "app.db3");
            _database = new SQLiteAsyncConnection(dbPath);

        }

        public async Task InitAsync()
        {

            // Ahora crea tus tablas
            await _database.CreateTableAsync<BoxModel>();
            await _database.CreateTableAsync<ItemsBoxModel>();
            // ... (y tus otras tablas como ItemsBoxModel)
        }
        public Task<BoxModel[]> GetBoxesAsync()
        {
            return _database.Table<BoxModel>().ToArrayAsync();
        }
        // Guardar (Insertar o Actualizar) un item
        public Task<int> SaveBoxAsync(BoxModel box)
        {
            if (box.Id != 0)
            {
                // Actualizar (Update)
                return _database.UpdateAsync(box);
            }
            else
            {
                // Insertar (Insert)
                return _database.InsertAsync(box);
            }
        }
        //public Task<List<ItemsBoxModel>> GetItemsAsync()
        //{
        //    return _database.Table<ItemsBoxModel>().ToListAsync();
        //}

        //// Obtener un item por ID
        //public Task<ItemsBoxModel> GetItemAsync(int id)
        //{
        //    return _database.Table<ItemsBoxModel>()
        //                    .Where(i => i.Id == id)
        //                    .FirstOrDefaultAsync();
        //}

        //// Guardar (Insertar o Actualizar) un item
        //public Task<int> SaveItemAsync(ItemsBoxModel item)
        //{
        //    if (item.Id != 0)
        //    {
        //        // Actualizar (Update)
        //        return _database.UpdateAsync(item);
        //    }
        //    else
        //    {
        //        // Insertar (Insert)
        //        return _database.InsertAsync(item);
        //    }
        //}

        //// Borrar un item
        //public Task<int> DeleteItemAsync(ItemsBoxModel item)
        //{
        //    return _database.DeleteAsync(item);
        //}
    }
}

