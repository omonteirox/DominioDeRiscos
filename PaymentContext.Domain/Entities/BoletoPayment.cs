using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Domain.Entities
{
    public class BoletoPayment : Payment
    {
        public BoletoPayment(string barCode, Email email, string boletoNumber, DateTime paidDate, DateTime expireDate, decimal total, decimal totalPaid,
             Address address, Document document, string payer) : base(paidDate, expireDate, total, totalPaid, address, document, payer)
        {
            BarCode = barCode;
            Email = email;
            BoletoNumber = boletoNumber;
        }

        public string BarCode { get; private set; }
        public Email Email { get; private set; }
        public string BoletoNumber { get; private set; }
    }
}