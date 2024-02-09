namespace AutoService.Payment.Infrastructure.Communication.DTOs
{
    public class CustomerDTO
    {
        public string @object { get; set; }
        public string id { get; set; }
        public string dateCreated { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public object company { get; set; }
        public object phone { get; set; }
        public string mobilePhone { get; set; }
        public object address { get; set; }
        public object addressNumber { get; set; }
        public object complement { get; set; }
        public object province { get; set; }
        public object postalCode { get; set; }
        public string cpfCnpj { get; set; }
        public string personType { get; set; }
        public bool deleted { get; set; }
        public object additionalEmails { get; set; }
        public object externalReference { get; set; }
        public bool notificationDisabled { get; set; }
        public object observations { get; set; }
        public object municipalInscription { get; set; }
        public object stateInscription { get; set; }
        public bool canDelete { get; set; }
        public object cannotBeDeletedReason { get; set; }
        public bool canEdit { get; set; }
        public object cannotEditReason { get; set; }
        public object city { get; set; }
        public object state { get; set; }
        public string country { get; set; }
    }
}
