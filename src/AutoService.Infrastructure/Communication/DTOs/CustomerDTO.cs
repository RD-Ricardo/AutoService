namespace AutoService.Infrastructure.Communication.DTOs
{
    public class CustomerDTO
    {
        public string @object { get; set; }
        public string Id { get; set; }
        public string DateCreated { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public object Company { get; set; }
        public object Phone { get; set; }
        public string MobilePhone { get; set; }
        public object Address { get; set; }
        public object AddressNumber { get; set; }
        public object Complement { get; set; }
        public object Province { get; set; }
        public object PostalCode { get; set; }
        public string cpfCnpj { get; set; }
        public string PersonType { get; set; }
        public bool Deleted { get; set; }
        public object AdditionalEmails { get; set; }
        public object ExternalReference { get; set; }
        public bool NotificationDisabled { get; set; }
        public object Observations { get; set; }
        public object MunicipalInscription { get; set; }
        public object StateInscription { get; set; }
        public bool CanDelete { get; set; }
        public object CannotBeDeletedReason { get; set; }
        public bool CanEdit { get; set; }
        public object CannotEditReason { get; set; }
        public object City { get; set; }
        public object State { get; set; }
        public string Country { get; set; }
    }
}
