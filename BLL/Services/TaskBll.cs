using BLL.InterfacesBL;
using DTO.Classes;
using DAL.InterfacesDal;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.Enums;


namespace BLL.Services
{
    public class TaskBll: ITaskBll
    {
        private readonly ITaskDal _taskDal;

        public TaskBll(ITaskDal taskDal)
        {
            _taskDal = taskDal;
        }
        public async Task<List<TaskDtoGetSet>> GetAllAsync()
        {
            var taskDalList = await _taskDal.GetAllTasksAsync();
            return ConvertDalToDtoList(taskDalList) ?? new List<TaskDtoGetSet>();
        }


        public async Task AddAsync(TaskDto task) =>
         await _taskDal.AddTaskAsync(ConvertTaskDtoToTaskDal(task));

        public async Task UpdateAsync(int id, TaskDtoGetSet task)=>
            await _taskDal.UpdateTaskAsync(id, ConvertTaskDtoGetSetToTaskDal(task));

        public async Task DeleteAsync(int id)=>
        await _taskDal.DeleteTaskAsync(id);


        //converters

        private TaskDal ConvertTaskDtoToTaskDal(TaskDto taskDto) =>
        new TaskDal(
               title: taskDto.Title,
               description: taskDto.Description,
               date: taskDto.Date,
               status: (StatusDal)Enum.Parse(typeof(StatusDal), taskDto.Status.ToString()),
               priority: (PriorityDal)Enum.Parse(typeof(PriorityDal), taskDto.Priority.ToString())
           );
        private TaskDal ConvertTaskDtoGetSetToTaskDal(TaskDtoGetSet taskDto) =>
         new TaskDal(
                id: taskDto.Id,
                title: taskDto.Title,
                description: taskDto.Description,
                date: taskDto.Date,
                status: (StatusDal)Enum.Parse(typeof(StatusDal), taskDto.Status.ToString()),
                priority: (PriorityDal)Enum.Parse(typeof(PriorityDal), taskDto.Priority.ToString())
            );

        private TaskDtoGetSet ConvertDalToDto(TaskDal taskDal) =>
         new TaskDtoGetSet(
                id: taskDal.Id,
                title: taskDal.Title,
                description: taskDal.Description,
                date: taskDal.Date,
                status: (StatusDto)taskDal.Status,
                priority: (PriorityDto)taskDal.Priority
            );

        private List<TaskDtoGetSet> ConvertDalToDtoList(List<TaskDal> taskDals) =>
            taskDals.Select(taskDal => ConvertDalToDto(taskDal)).ToList();

    }
}
