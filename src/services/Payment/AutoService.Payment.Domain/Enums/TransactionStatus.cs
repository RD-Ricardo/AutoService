namespace AutoService.Payment.Domain.Enums
{
    public enum TransactionStatus
    {
        Denied = 0,
        Paid = 1,
        Authorized = 2,
        reversed = 3
    }
}
