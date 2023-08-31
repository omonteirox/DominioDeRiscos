using Flunt.Notifications;
using Flunt.Validations;
using PaymentContext.Domain.Enums;
using PaymentContext.Shared.Commands;

namespace PaymentContext.Domain.Commands
{
    public class CreatePayPalSubscriptionCommand : Notifiable<Notification>, Icommand
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Document { get; set; }
        public string Email { get; set; }
        public string PaymentNumber { get; set; }
        public string TransactionCode { get; set; }
        public DateTime PaidDate { get; set; }
        public DateTime ExpireDate { get; set; }
        public decimal Total { get; set; }
        public decimal TotalPaid { get; set; }
        public string Payer { get; set; }
        public string PayerDocument { get; set; }
        public EDocumentType PayerDocumentType { get; set; }
        public string PayerEmail { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string Neighborhood { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract<Notification>().Requires()
                .IsLowerThan(FirstName, 3, "Name.Firstname", "O nome deve conter pelo menos 3 caracteres")
                .IsLowerThan(LastName, 3, "Name.Lastname", "O Sobrenome deve conter pelo menos 3 caracteres")
                .IsGreaterThan(LastName, 40, "Name.Firstname", "O nome deve conter no máximo 40 caracteres")
                .IsEmail(Email, "Email.Address", "E-mail inválido")
                );
        }
    }
}