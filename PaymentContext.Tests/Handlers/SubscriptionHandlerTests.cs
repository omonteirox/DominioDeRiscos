using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Handlers;
using PaymentContext.Tests.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentContext.Tests.Handlers
{
    [TestClass]
    public class SubscriptionHandlerTests
    {
        [TestMethod]
        public void ShouldReturnErrorWhenDocumentExists()
        {
            var handler = new SubscriptionHandler(new FakeStudentRepository(), new FakeEmailService());
            var command = new CreateBoletoSubscriptionCommand();
            command.FirstName = "Gustavo";
            command.LastName = "Monteiro";
            command.Document = "99999999999";
            command.Email = "teste@teste.com";
            command.PaymentNumber = "123456789";
            command.Barcode = "123456789";
            command.BoletoNumber = "123456789";
            command.PaidDate = DateTime.Now;
            command.ExpireDate = DateTime.Now.AddMonths(1);
            command.Total = 60;
            command.TotalPaid = 60;
            command.Payer = "Gustavo Monteiro";
            command.PayerDocument = "99999999999";
            command.PayerDocumentType = EDocumentType.CPF;
            command.PayerEmail = "teste@teste.com";
            command.Street = "Rua 1";
            command.Number = "123";
            command.Neighborhood = "Bairro Legal";
            command.State = "SP";
            command.Country = "Brasil";
            command.ZipCode = "12345678";
            handler.Handle(command);
            Assert.AreEqual(false, handler.IsValid);
        }

        [TestMethod]
        public void ShouldReturnSuccessWhenDocumentNotExists()
        {
            var handler = new SubscriptionHandler(new FakeStudentRepository(), new FakeEmailService());
            var command = new CreateBoletoSubscriptionCommand();
            command.FirstName = "Gustavo";
            command.LastName = "Monteiro";
            command.Document = "99999999939";
            command.Email = "teste@teste.com";
            command.PaymentNumber = "123456789";
            command.Barcode = "123456789";
            command.BoletoNumber = "123456789";

            command.PaidDate = DateTime.Now;
            command.ExpireDate = DateTime.Now.AddMonths(1);
            command.Total = 60;
            command.TotalPaid = 60;
            command.Payer = "Gustavo Monteiro";
            command.PayerDocument = "99999999939";
            command.PayerDocumentType = EDocumentType.CPF;
            command.PayerEmail = "teste@teste.com";
            command.Street = "Rua 1";
            command.Number = "123";
            command.Neighborhood = "Bairro Legal";
            command.State = "SP";
            command.Country = "Brasil";
            command.ZipCode = "12345678";
            handler.Handle(command);
            Assert.AreEqual(true, handler.IsValid);
        }
    }
}