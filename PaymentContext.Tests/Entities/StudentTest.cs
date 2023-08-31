using PaymentContext.Domain.Entities;
using PaymentContext.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PaymentContext.Tests.Entities
{
    [TestClass]
    public class StudentTest
    {
        //[TestMethod]
        //public void TestMethod1()
        //{
        //}
        private readonly Student _student;

        private readonly Subscription _subscription;
        private readonly Address _address;
        private readonly Document _document;
        private readonly Email _email;
        private readonly Name _name;

        public StudentTest()
        {
            _name = new Name("Naruto", "Uzumaki");
            _document = new Document("02153472114", Domain.Enums.EDocumentType.CPF);
            _email = new Email("UzumakiNaruto@naruto.com");
            _student = new Student(_name, _document, _email);
            _subscription = new Subscription(null);
            var address = new Address("Rua 1", "1234", "Bairro Legal", "São Paulo", "BR", "13400000");
        }

        [TestMethod]
        public void ShouldReturnErrorWhenHadActiveSubscription()
        {
            var subscription = new Subscription(null);
            var payment = new CreditCardPayment("NarutoZumaki", "1234", "123", DateTime.Now, DateTime.Now.AddDays(5), 10, 10, _address, _document, "ZumakiNaruto");
            subscription.AddPayment(payment);
            _student.AddSubscription(subscription);
            _student.AddSubscription(_subscription);

            Assert.AreEqual(false, _student.IsValid);
        }

        [TestMethod]
        public void ShouldReturnErrorWhenSubscriptionHasNoPayment()
        {
            var payment = new CreditCardPayment("GustavoMonteiro", "1234", "123", DateTime.Now, DateTime.Now.AddDays(5), 10, 10, _address, _document, "gustavo");

            _student.AddSubscription(_subscription);

            Assert.AreEqual(false, _student.IsValid);
        }

        [TestMethod]
        public void ShouldReturnErrorWhenHadNoActiveSubscription()
        {
            _subscription.Inactivate();
            _student.AddSubscription(_subscription);
            Assert.AreEqual(false, _student.IsValid);
        }

        [TestMethod]
        public void ShouldReturnSucessWhenHadNoActiveSubscription()
        {
            var payment = new CreditCardPayment("GustavoMonteiro", "1234", "123", DateTime.Now, DateTime.Now.AddDays(5), 10, 10, _address, _document, "gustavo");
            _subscription.AddPayment(payment);
            _student.AddSubscription(_subscription);

            foreach (var x in _student.Notifications)
            {
                Console.WriteLine(x.Message);
            }
            Assert.AreEqual(true, _student.IsValid);
        }
    }
}