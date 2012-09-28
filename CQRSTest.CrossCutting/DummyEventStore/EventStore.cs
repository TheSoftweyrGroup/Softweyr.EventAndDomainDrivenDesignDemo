namespace CQRSTest.WriteModel.Events
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.Text;
    using System.Xml;

    using CQRSTest.Models;

    public class EventStore : IEventStore
    {
        public EventStoreContext db = new EventStoreContext();

        public IEnumerable<object> GetEventsFor(Guid id)
        {
            return
                db.Events.Where(@event => @event.AggregateId == id).OrderBy(@event => @event.EventId).Select(
                    @event => new { @event.EventType, @event.EventBody }).ToList().Select(
                        @event =>
                            {
                                using (var stringReader = new StringReader(@event.EventBody))
                                using (var xmlReader = XmlReader.Create(stringReader))
                                {
                                    var serializer = new DataContractSerializer(AppDomain.CurrentDomain.GetAssemblies().SelectMany(
                                        asm => asm.GetTypes().Where(type => type.FullName == @event.EventType)).First());
                                    return serializer.ReadObject(xmlReader);
                                }
                            });
        }

        public void Store(Guid customerId, object @event)
        {
            var sb = new StringBuilder();
            using (var sw = new StringWriter(sb))
            using (var xmlWriter = XmlWriter.Create(sw))
            {
                var serializer = new DataContractSerializer(@event.GetType());
                serializer.WriteObject(xmlWriter, @event);
                xmlWriter.Flush();
                xmlWriter.Close();
                db.Events.Add(new Event { AggregateId = customerId, EventType = @event.GetType().FullName, EventBody = sb.ToString() });
            }
            
            db.SaveChanges();
        }
    }
}