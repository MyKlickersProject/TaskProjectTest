using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using DAL.InterfacesDal;

namespace DAL.DataAccessDal
{
    public class JsonFileDataAccess : IDataAccess
    {
        private readonly string _basePath = "../../../DataBase";

        private string GetFilePath<T>()
        {
            var fileName = typeof(T).Name.ToLower() + "s.json";
            return Path.Combine(_basePath, fileName);
        }

        private async Task<List<T>> ReadFromFileAsync<T>()
        {
            var filePath = GetFilePath<T>();

            if (!File.Exists(filePath))
            {
                return new List<T>();
            }

            var json = await File.ReadAllTextAsync(_basePath);
            return JsonSerializer.Deserialize<List<T>>(json) ?? new List<T>();
        }

        private async Task WriteToFileAsync<T>(List<T> data)
        {
            var filePath = GetFilePath<T>();
            var json = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
            await File.WriteAllTextAsync(filePath, json);
        }

        public async Task<List<T>> GetAllAsync<T>()
        {
            return await ReadFromFileAsync<T>();
        }

        public async Task AddAsync<T>(T newItem)
        {
            var data = await ReadFromFileAsync<T>();

            // Assign identity ID
            var idProperty = typeof(T).GetProperty("Id");
            if (idProperty != null)
            {
                var lastId = data.Max(item => (int?)idProperty.GetValue(item)) ?? 0;
                idProperty.SetValue(newItem, lastId + 1);
            }

            // Set IsActive = true
            var isActiveProperty = typeof(T).GetProperty("IsActive");
            if (isActiveProperty != null)
            {
                isActiveProperty.SetValue(newItem, true);
            }

            // Set InsertDate = DateTime.Today
            var insertDateProperty = typeof(T).GetProperty("InsertDate");
            if (insertDateProperty != null)
            {
                insertDateProperty.SetValue(newItem, DateTime.Today);
            }

            data.Add(newItem);
            await WriteToFileAsync(data);
        }


        public async Task UpdateAsync<T>(Func<T, bool> predicate, T updatedItem)
        {
            var data = await ReadFromFileAsync<T>();
            var index = data.FindIndex(new Predicate<T>(predicate));

            if (index == -1)
            {
                throw new KeyNotFoundException("Item not found in the database.");
            }

            data[index] = updatedItem;
            await WriteToFileAsync(data);
        }

        public async Task DeleteByIdAsync<T>(int id) where T : class
        {
            var data = await ReadFromFileAsync<T>();
            var item = data.FirstOrDefault(obj =>
            {
                var idProperty = obj.GetType().GetProperty("Id");
                return idProperty != null && (int)idProperty.GetValue(obj) == id;
            });

            if (item == null)
            {
                throw new KeyNotFoundException("Item not found in the database.");
            }

            var isActiveProperty = item.GetType().GetProperty("IsActive");
            var updateDateProperty = item.GetType().GetProperty("UpdateDate");

            //if (isActiveProperty != null)
            //{
                isActiveProperty.SetValue(item, false);
            //}

            //if (updateDateProperty != null)
            //{
                updateDateProperty.SetValue(item, DateTime.Today);
            //}

            await WriteToFileAsync(data);
        }

    }

}
