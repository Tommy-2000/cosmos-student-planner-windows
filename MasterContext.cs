using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace CosmosStudentPlanner.Model
{

    public class MasterContext : DbContext
    {
        public DbSet<Events> Event { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Reminder> Reminders { get; set; }
        public DbSet<HomeworkEvent> HomeworkEvents { get; set; }
        public DbSet<MeetingEvent> MeetingEvents { get; set; }
        public DbSet<ActivityEvent> ActivityEvents { get; set; }
        public DbSet<PersonalEvent> PersonalEvents { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=MasterData.db");
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Events>()
                .HasKey(e => e.EventsId);

            modelBuilder.Entity<HomeworkEvent>()
                .HasKey(e => e.HomeworkEventId);

            modelBuilder.Entity<MeetingEvent>()
                .HasKey(e => e.MeetingEventId);

            modelBuilder.Entity<ActivityEvent>()
                .HasKey(e => e.ActivityEventId);

            modelBuilder.Entity<PersonalEvent>()
                .HasKey(e => e.PersonalEventId);

            modelBuilder.Entity<Events>()
                .Property(p => p.EventsTitle)
                .IsRequired();

            modelBuilder.Entity<Events>()
                .Property(p => p.EventsDescription);

            modelBuilder.Entity<Events>()
                .Property(p => p.EventsDatePicker)
                .IsRequired();

            modelBuilder.Entity<Events>()
                .Property(p => p.EventsTimePicker)
                .IsRequired();

            modelBuilder.Entity<Events>()
                .Property(p => p.EventsInkNote);



            modelBuilder.Entity<Lesson>()
                .HasKey(e => e.LessonId);

            modelBuilder.Entity<Lesson>()
                .Property(p => p.LessonName)
                .IsRequired();

            modelBuilder.Entity<Lesson>()
                .Property(p => p.TeacherName);

            modelBuilder.Entity<Lesson>()
                .Property(p => p.LessonTime);

            modelBuilder.Entity<Lesson>()
                .Property(p => p.RoomName);



            modelBuilder.Entity<Reminder>()
                .HasKey(e => e.ReminderId);

            modelBuilder.Entity<Reminder>()
                .Property(p => p.ReminderDatePicker)
                .IsRequired();

            modelBuilder.Entity<Reminder>()
                .Property(p => p.ReminderTimePicker)
                .IsRequired();

            modelBuilder.Entity<Reminder>()
                .Property(p => p.ReminderFrequency)
                .IsRequired();

        }


        public class HomeworkEvent
        {
            public int HomeworkEventId { get; set; }
            
            public List<Events> Events { get; set; }

        }


        public class MeetingEvent
        {
            public int MeetingEventId { get; set; }

            public List<Events> Events { get; set; }

        }


        public class ActivityEvent 
        {
            public int ActivityEventId { get; set; }

            public List<Events> Events { get; set; }

        }


        public class PersonalEvent
        {
            public int PersonalEventId { get; set; }

            public List<Events> Events { get; set; }

        }


        public class Events : INotifyPropertyChanged
        {
            public int EventsId { get; set; }

            public string EventsTitle { get; set; }
            public string EventsDescription { get; set; }
            public DateTimeOffset EventsDatePicker { get; set; }
            public TimeSpan EventsTimePicker { get; set; }
            public byte[] EventsInkNote { get; set; }


            public int HomeworkEventId { get; set; }
            public HomeworkEvent HomeworkEvent { get; set; }
            public int MeetingEventId { get; set; }
            public MeetingEvent MeetingEvent { get; set; }
            public int ActivityEventId { get; set; }
            public ActivityEvent ActivityEvent { get; set; }
            public int PersonalEventId { get; set; }
            public PersonalEvent PersonalEvent { get; set; }

            public event PropertyChangedEventHandler PropertyChanged;
            private void NotifyPropertyChanged(string propertyName)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }

        }


        public class Lesson : INotifyPropertyChanged
        {
            public int LessonId { get; set; }
            public string LessonName { get; set; }
            public string TeacherName { get; set; }
            public DateTime LessonTime { get; set; }
            public string RoomName { get; set; }

            public event PropertyChangedEventHandler PropertyChanged;
            private void NotifyPropertyChanged(string propertyName)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }

        }


        public class Reminder : INotifyPropertyChanged
        {
            public int ReminderId { get; set; }
            public DateTimeOffset ReminderDatePicker { get; set; }
            public TimeSpan ReminderTimePicker { get; set; }
            public TimeSpan ReminderFrequency { get; set; }

            public event PropertyChangedEventHandler PropertyChanged;
            private void NotifyPropertyChanged(string propertyName)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }

        }

    }
}
