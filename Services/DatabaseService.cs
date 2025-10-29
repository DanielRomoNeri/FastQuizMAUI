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
            //await _database.DropTableAsync<BoxModel>();
            //await _database.DropTableAsync<ItemsBoxModel>();
            await _database.CreateTableAsync<BoxModel>();
            await _database.CreateTableAsync<ItemsBoxModel>();
            await _database.CreateTableAsync<BoxCategoryModel>();

            //await _database.DropTableAsync<BoxCategoryModel>();

            await SeedDataAsync();
        }
        private async Task SeedDataAsync()
        {
            var firstCategory = await _database.Table<BoxCategoryModel>().FirstOrDefaultAsync();
            if (firstCategory != null)
            {
                return; // Los datos ya existen, no es necesario sembrar
            }

            List<BoxCategoryModel> itemsCategories = new List<BoxCategoryModel>
            {
                new BoxCategoryModel { Category = "Definition" },
                new BoxCategoryModel { Category = "Translation" },
                new BoxCategoryModel { Category = "Other" },
            };
            await _database.InsertAllAsync(itemsCategories);
        }
        public async Task<BoxModel[]> GetBoxesAsync()
        {
            return await _database.Table<BoxModel>().ToArrayAsync();
        }
        //Guardar(Insertar o Actualizar) un item
        public async Task<int> SaveBoxAsync(BoxModel box)
        {
            if (box.Id != 0)
            {
                // Actualizar (Update)
                return await _database.UpdateAsync(box);
            }
            else
            {
                // Insertar (Insert)
                return await _database.InsertAsync(box);
            }
        }
        public async Task<ItemsBoxModel[]> GetItemsAsync(int boxId)
        {
            return await _database.Table<ItemsBoxModel>().Where(i => i.BoxId == boxId).ToArrayAsync();
        }
        public async Task<List<BoxCategoryModel>> GetBoxCategoriesAsync()
        {
            return await _database.Table<BoxCategoryModel>().ToListAsync();
        }
        //// Obtener un item por ID
        //public Task<ItemsBoxModel> GetItemAsync(int id)
        //{
        //    return _database.Table<ItemsBoxModel>()
        //                    .Where(i => i.Id == id)
        //                    .FirstOrDefaultAsync();
        //}

        // Guardar (Insertar o Actualizar) un item
        public Task<int> SaveItemAsync(ItemsBoxModel item)
        {
            if (item.Id != 0)
            {
                // Actualizar (Update)
                return _database.UpdateAsync(item);
            }
            else
            {
                // Insertar (Insert)
                return _database.InsertAsync(item);
            }
        }

        public Task<int> SaveItemsListAsync(ItemsBoxModel[] items)
        {
            return _database.InsertAllAsync(items);
        }

        //// Borrar un item
        //public Task<int> DeleteItemAsync(ItemsBoxModel item)
        //{
        //    return _database.DeleteAsync(item);
        //}
    }
}

