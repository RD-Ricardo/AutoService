using AutoService.Core.DomainObjects;

namespace AutoService.Domain.Entities
{
    public class Schedule : AggregateRoot 
    {
        public Guid ServiceId { get; set; }
        public Guid ProfessionalId { get; set; }
        public Guid CustomerId { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Hour { get; set; }
        public Schedule(Guid serviceId, 
            Guid professionalId, 
            Guid customerId, 
            DateTime date, 
            TimeSpan hour)
        {
            ServiceId = serviceId;
            ProfessionalId = professionalId;
            CustomerId = customerId;
            Date = date;
            Hour = hour;
        }
        
        //EF
        protected Schedule() { }
        public Customer Customer { get; set; }
        public Professional Professional { get; set; }
        public Service Service { get; set; }
    }
}
