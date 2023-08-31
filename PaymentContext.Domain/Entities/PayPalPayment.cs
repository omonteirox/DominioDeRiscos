using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Domain.Entities
{
    public class PayPalPayment : Payment
    {
        public PayPalPayment(Email email, string transactionCode, DateTime paidDate, DateTime expireDate, decimal total, decimal totalPaid,
            Address address, Document document, string payer) : base(paidDate, expireDate, total, totalPaid, address, document, payer)
        {
            Email = email;
            TransactionCode = transactionCode;
        }

        public Email Email { get; private set; }
        public string TransactionCode { get; private set; }
    }
}