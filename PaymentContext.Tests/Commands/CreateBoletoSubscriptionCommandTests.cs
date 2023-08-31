using PaymentContext.Domain.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentContext.Tests.Commands
{
    [TestClass]
    public class CreateBoletoSubscriptionCommandTests
    {
        [TestMethod]
        public void ShouldReturnErrorWhenNameIsInvalid()
        {
            var command = new CreateBoletoSubscriptionCommand();
            command.FirstName = "";
            command.LastName = "";

            command.Validate();

            Assert.AreEqual(false, command.IsValid);
        }

        [TestMethod]
        public void ShouldReturnSuccessWhenNameIsValid()
        {
            var command = new CreateBoletoSubscriptionCommand();
            command.FirstName = "Gustavo";
            command.LastName = "Monteiro";

            command.Validate();

            Assert.AreEqual(true, command.IsValid);
        }
    }
}