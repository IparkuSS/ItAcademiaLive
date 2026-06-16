namespace Matvey.Live.Api.Services
{
    public class DepositRequest
    {
        public decimal Amount { get; set; }
    }

    public class WithdrawRequest
    {
        public decimal Amount { get; set; }
    }

    // Response DTOs
    public class AccountResponse
    {
        public string UserId { get; set; }
        public string Username { get; set; }
        public decimal Balance { get; set; }
    }

    public class TransactionResponse
    {
        public bool Success { get; set; }
        public decimal CurrentBalance { get; set; }
        public string Message { get; set; }
    }
}
