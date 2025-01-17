using DAL.InterfacesDal;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DataAccessDal
{
    internal class DalTask : ITaskDal
    {
        private readonly IDataAccess _dataAccess;

        public DalTask(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public async Task<List<TaskDal>> GetAllTasksAsync()
        {
            return await _dataAccess.GetAllAsync<TaskDal>();
        }

        public async Task AddTaskAsync(TaskDal newTask)
        {
            await _dataAccess.AddAsync(newTask);
        }

        public async Task UpdateTaskAsync(int id, TaskDal updatedTask)
        {
            await _dataAccess.UpdateAsync<TaskDal>(task => task.Id == id, updatedTask);
        }

        public async Task DeleteTaskAsync(int id)
        {
            await _dataAccess.DeleteByIdAsync<TaskDal>(id);
        }

        //public Task<List<TaskDal>> GetAllTasksAsync()
        //{
        //    try
        //    {
        //        var data = new List<TaskDal>();
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        //public Task<bool> UpdateDataAsync(string id, TaskDal data)
        //{
        //    try
        //    {

        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        //public Task<bool> (TaskDal data)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
