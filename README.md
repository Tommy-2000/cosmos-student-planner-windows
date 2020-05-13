# Cosmos Student Planner - Windows 10 Desktop application

This was my final end-of-year college project that was built for Windows 10 using UWP (Universal Windows Platform) libraries combined with .NET Core, and Entity Framework Core and written in XAML and C# coding languages. This application was made so that students could organise their school life and overall time management, and was developed in Visual Studio 2017/2019. Certain features were not completed, such as the reminders and timeline, but other functionality (like the ability to handwrite notes using a tablet pen) was developed using the Windows Ink NuGet package and was implemented through the C# back-end code of the application (See example below).

In this example, once the page has been initialised and loaded into the stack, Windows 10 will recognise that this application supports Windows Ink and the following pen inputs (as well as whether the user prefers to draw left or right-handed).

```c#

public CreateEventPage()
        {
            this.InitializeComponent();
            Loaded += CreateEventPage_Loaded;

            Windows.UI.ViewManagement.UISettings settings =
                new Windows.UI.ViewManagement.UISettings();
            HorizontalAlignment alignment =
                (settings.HandPreference ==
                Windows.UI.ViewManagement.HandPreference.RightHanded) ?
                HorizontalAlignment.Left : HorizontalAlignment.Right;
            EventInkToolbar.HorizontalAlignment = alignment;

            EventInkNote.InkPresenter.InputDeviceTypes =
            Windows.UI.Core.CoreInputDeviceTypes.Mouse |
            Windows.UI.Core.CoreInputDeviceTypes.Touch |
            Windows.UI.Core.CoreInputDeviceTypes.Pen;

        }
```

This application also made use of Entity Framework Core as a means of data management. In this case, each lesson and event that is added to the app, will be recorded in a new local SQLite database that has been created using EF migrations and data-modeling using C# objects (See example below).

```

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
```


A time management and calendar application for students (Secondary School to University).


* Make the most of your day with daily reminders - Reminders can help you keep on top of whatever's happening in your academia and your day-by-day schedule.


* Share with other students via email. Share your events and deadlines with other students or peers via Windows 10 Email.


* Add typed or handwritten notes with your Windows Pen to each event - Visualise and gather ideas and notes whether typed or handwritten with the Windows Ink Workspace (Only compatible with pen-enabled Windows 10 devices).


* Add custom lessons to your own academic timeline - Add your lessons to a personal timeline that visualises and tracks each event or deadline that you create.
