using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.InterfacesDal
{
    public interface ITaskDal
    {
        Task<List<TaskDal>> GetAllTasksAsync();
        Task AddTaskAsync(TaskDal newtask);
        Task UpdateTaskAsync(int id, TaskDal taskDal);
        Task DeleteTaskAsync(int id);
    }
}
