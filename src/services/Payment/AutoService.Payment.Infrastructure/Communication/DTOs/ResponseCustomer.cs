namespace AutoService.
{
    public class ResponseCustomerDTO
    {
        public string @object { get; set; }
        public bool hasMore { get; set; }
        public int totalCount { get; set; }
        public int limit { get; set; }
        public int offset { get; set; }
        public List<CustomerDTO> data { get; set; }
    }
}
