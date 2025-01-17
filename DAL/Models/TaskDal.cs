using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class TaskDal
    {
        public int Id { get; private set; }
        public string Title { get; private set; }
        public string? Description { get; private set; }
        public DateTime Date { get; private set; }
        public StatusDal Status { get; private set; }
        public PriorityDal Priority { get; private set; }
        public bool? IsActive { get; private set; } = true;
        public DateTime? InsertDate { get; private set; }
        public DateTime? UpdateDate { get; private set; }


        public TaskDal(string title, string? description, DateTime date, StatusDal status, PriorityDal priority)
        {

            Title = title;
            Description = description;
            Date = date;
            Status = status;
            Priority = priority;
            IsActive = true;
            InsertDate = DateTime.Today;
        }

        public TaskDal(int id, string title, string? description, DateTime date, StatusDal status, PriorityDal priority)
        {
            Id = id;
            Title = title;
            Description = description;
            Date = date;
            Status = status;
            Priority = priority;
            IsActive = true;
            UpdateDate = DateTime.Today;
        }

        public void InsertTask()
        {

        }

        public void UpdateTask() { }
        public void DeleteTask() { }


        //בהוספה- פשוט מתמלאים כל השדות
        //    ID רץ.
        //    במחיקה- מקבלים את הID
        //        ומשנים ללא אקטיבי, עם תאריך עדכון של היום

        //        בעדכון- מקבלים במסך את כל הנתונים
        //        גם את הID מקבלים מאחורי הקלעים
        //        משנים את האוביקט בקליינט
        //        ושולחים את כולו לסרבר
        //        בסרבר מעדכנים את כל השדות של המשימה
        //        וכמובן משנים את תאריך העדכון

    }
}
