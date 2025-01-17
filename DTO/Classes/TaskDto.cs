using DTO.Enums;
using System;

namespace DTO.Classes
{
    public class TaskDto
    {
        public string Title { get; private set; }
        public string? Description { get; private set; }
        public DateTime Date { get; private set; }
        public StatusDto Status { get; private set; }
        public PriorityDto Priority { get; private set; }

        public TaskDto(string title, string? description, DateTime date, StatusDto status, PriorityDto priority)
        {
            Title = title;
            Description = description;
            Date = date;
            Status = status;
            Priority = priority;
        }
    }

    public class TaskDtoGetSet : TaskDto
    {
        public int Id { get; private set; } 
        public TaskDtoGetSet(int id, string title, string? description, DateTime date, StatusDto status, PriorityDto priority)
            : base(title, description, date, status, priority)
        {
            Id = id;
        }
    }
}
