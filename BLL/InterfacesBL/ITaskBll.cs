using DTO.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.InterfacesBL
{
    public interface ITaskBll
    {
        Task<List<TaskDtoGetSet>> GetAllAsync();
        Task AddAsync(TaskDto entity);
        Task UpdateAsync(int id, TaskDtoGetSet entity);
        Task DeleteAsync(int id);
    }
}
