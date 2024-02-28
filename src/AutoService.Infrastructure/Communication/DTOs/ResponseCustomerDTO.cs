namespace AutoService.Infrastructure.Communication.DTOs
{
    public class ResponseCustomerDTO
    {
        public string @object { get; set; }
        public bool HasMore { get; set; }
        public int totalCount { get; set; }
        public int Limit { get; set; }
        public int Offset { get; set; }
        public List<CustomerDTO> Data { get; set; }
    }
}


