﻿using Flunt.Notifications;
using Flunt.Validations;
using PaymentContext.Shared.Entities;

namespace PaymentContext.Domain.Entities
{
    public class Subscription : Entity
    {
        public Subscription(DateTime? expireDate)
        {
            CreateDate = DateTime.Now;
            LastUpdateDate = DateTime.Now;
            Active = true;
            ExpireDate = expireDate;
            _payments = new List<Payment>();
        }

        public DateTime CreateDate { get; private set; }
        public DateTime LastUpdateDate { get; private set; }
        public DateTime? ExpireDate { get; private set; }
        public bool Active { get; private set; }

        public IReadOnlyCollection<Payment> Payments
        { get { return _payments.ToArray(); } }

        private IList<Payment> _payments;

        public void AddPayment(Payment payment)
        {
            AddNotifications(new Contract<Notification>().Requires().IsGreaterThan(DateTime.Now, payment.PaidDate, "Subscriptions.Payments", "A data do pagamento deve ser futura"));
            _payments.Add(payment);
        }

        public void Activate()
        {
            Active = true;
            LastUpdateDate = DateTime.Now;
        }

        public void Inactivate()
        {
            Active = false;
            LastUpdateDate = DateTime.Now;
        }
    }
}