using Flunt.Notifications;
using Flunt.Validations;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Entities;

namespace PaymentContext.Domain.Entities
{
    public abstract class Payment : Entity
    {
        protected Payment(DateTime paidDate, DateTime expireDate, decimal total, decimal totalPaid, Address address, Document document, string payer)
        {
            PaidDate = paidDate;
            ExpireDate = expireDate;
            Total = total;
            TotalPaid = totalPaid;
            Number = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 10).ToUpper();
            Address = address;
            Document = document;
            Payer = payer;
            AddNotifications(new Contract<Notification>().Requires().IsGreaterThan(total, 0, "Payment.Total", "O total não pode ser 0").IsGreaterOrEqualsThan(TotalPaid, Total, "Payment.TotalPaid", "O valor pago é menor que o valor do boleto"));
        }

        public DateTime PaidDate { get; private set; }
        public DateTime ExpireDate { get; private set; }
        public decimal Total { get; private set; }
        public decimal TotalPaid { get; private set; }
        public string Number { get; private set; }
        public Address Address { get; private set; }
        public Document Document { get; private set; }
        public string Payer { get; private set; }
    }
}