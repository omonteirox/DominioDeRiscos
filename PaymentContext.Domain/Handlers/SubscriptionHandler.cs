using Flunt.Notifications;
using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Repositories;
using PaymentContext.Domain.Services;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Commands;
using PaymentContext.Shared.Handlers;

namespace PaymentContext.Domain.Handlers
{
    public class SubscriptionHandler : Notifiable<Notification>, IHandler<CreateBoletoSubscriptionCommand>
    {
        private readonly IStudentRepository _repository;
        private readonly IEmailService _emailService;

        public SubscriptionHandler(IStudentRepository repository, IEmailService emailService)
        {
            _repository = repository;
            _emailService = emailService;
        }

        public IcommandResult Handle(CreateBoletoSubscriptionCommand command)
        {
            command.Validate();
            if (command.IsValid == false)
            {
                AddNotifications(command);
                return new CommandResult(false, "Não foi possível realizar sua assinatura");
            }
            //verifica se o documento já foi cadastrado
            if (_repository.DocumentExists(command.Document))
            {
                AddNotification("Document", "Este CPF já está em uso");
            }
            // verifica se o email já está cadastrado
            if (_repository.EmailExists(command.Email))
            {
                AddNotification("Email", "Este Email já está em uso");
            }
            //gera os vos
            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document, EDocumentType.CPF);
            var email = new Email(command.Email);
            var address = new Address(command.Street, command.Number, command.Neighborhood, command.Country, command.Street, command.ZipCode);
            //gera as entidades
            var student = new Student(name, document, email);
            var subscription = new Subscription(DateTime.Now.AddMonths(1));
            var payment = new BoletoPayment(command.Barcode, email, command.BoletoNumber, command.PaidDate, command.ExpireDate, command.Total,
                command.TotalPaid, address, document, command.Payer);
            // relacionamentos
            subscription.AddPayment(payment);
            student.AddSubscription(subscription);

            // Agrupar as validações
            AddNotifications(name, document, email, address, student, subscription, payment);
            // checar as notificações
            if (IsValid == false)
                return new CommandResult(false, "Não foi possível realizar sua assinatura");

            // salva as informações
            _repository.CreateSubscription(student);
            // envia o email de boas vindas
            _emailService.Send(student.Name.ToString(), student.Email.ToString(), "Inscrição!", "Sua inscrição foi criada com êxito!");
            // retornar as informações

            return new CommandResult(true, "Assinatura realizada com sucesso");
        }
    }
}