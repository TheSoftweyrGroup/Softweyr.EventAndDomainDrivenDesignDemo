using System.Data.Entity;

namespace CQRSTest.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class EventStoreContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, add the following
        // code to the Application_Start method in your Global.asax file.
        // Note: this will destroy and re-create your database with every model change.
        // 
        // System.Data.Entity.Database.SetInitializer(new System.Data.Entity.DropCreateDatabaseIfModelChanges<CQRSTest.Models.CustomerSummaryContext>());

        public EventStoreContext()
            : base("name=EventStoreContext")
        {
        }

        public DbSet<Event> Events { get; set; }
        
    }

    public class Event
    {
        [Key]
        public int EventId { get; set; }

        public Guid AggregateId { get; set; }

        public string EventType { get; set; }

        public string EventBody { get; set; }
    }
}
