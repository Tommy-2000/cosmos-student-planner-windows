using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;



namespace CosmosStudentPlanner.MasterDataModel
{
    public class MasterDataContext : DbContext
    {
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<HomeworkEvent> HomeworkEvents { get; set; }
        public DbSet<MeetingsEvent> MeetingsEvents { get; set; }
        public DbSet<ActivitiesEvent> ActivitiesEvents { get; set; }
        public DbSet<PersonalEvent> PersonalEvents { get; set; }
        public DbSet<Reminder> Reminders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=MasterData.db");
        }
    }

    public class Lesson
    {
        public int LessonId { get; set; }
        public string LessonName { get; set; }
        public string TeacherName { get; set; }
        public DateTime LessonTime { get; set; }
        public string RoomName { get; set; }

    }

    public class Event
    {
        public int EventId { get; set; }
        public string EventTitle { get; set; }
        public string EventDescription { get; set; }
        public DateTimeOffset EventDatePicker { get; set; }
        public TimeSpan EventTimePicker { get; set; }
        public string EventInkNote_FilePath { get; set; }

        public List<Event> Events { get; set; }

    }

    public class HomeworkEvent
    {
        public int EventId { get; set; }
        public string HomeworkEventTitle { get; set; }
        public string HomeworkEventDescription { get; set; }
        public DateTimeOffset HomeworkEventDatePicker { get; set; }
        public TimeSpan HomeworkEventTimePicker { get; set; }
        public string HomeworkEventInkNote_FilePath { get; set; }

        public Event Event { get; set; }
        public List<Event> Events { get; set; }

    }


    public class MeetingsEvent
    {
        public int EventId { get; set; }
        public string EventTitle { get; set; }
        public string EventDescription { get; set; }
        public DateTime EventDatePicker { get; set; }
        public TimeSpan EventTimePicker { get; set; }
        public string EventInkNote_FilePath { get; set; }

        public Event Event { get; set; }
        public List<Event> Events { get; set; }

    }


    public class ActivitiesEvent
    {
        public int EventId { get; set; }
        public string EventTitle { get; set; }
        public string EventDescription { get; set; }
        public DateTime EventDatePicker { get; set; }
        public TimeSpan EventTimePicker { get; set; }
        public string EventInkNote_FilePath { get; set; }

        public Event Event { get; set; }
        public List<Event> Events { get; set; }

    }

    public class PersonalEvent
    {
        public int EventId { get; set; }
        public string EventTitle { get; set; }
        public string EventDescription { get; set; }
        public DateTime EventDatePicker { get; set; }
        public TimeSpan EventTimePicker { get; set; }
        public string EventInkNote_FilePath { get; set; }

        public Event Event { get; set; }
        public List<Event> Events { get; set; }

    }


    public class Reminder
    {
        public int EventId { get; set; }
        public Event Event { get; set; }

        public int ReminderId { get; set; }
        public DateTime ReminderDatePicker { get; set; }
        public TimeSpan ReminderTimePicker { get; set; }
        public TimeSpan ReminderFrequency { get; set; }

        public List<Reminder> Reminder { get; set; }

    }
}


