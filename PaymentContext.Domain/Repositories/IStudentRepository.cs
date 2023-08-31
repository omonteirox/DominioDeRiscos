using PaymentContext.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentContext.Domain.Repositories
{
    // Define o contrato para o repositório de estudantes
    public interface IStudentRepository
    {
        bool DocumentExists(string document);

        bool EmailExists(string email);

        void CreateSubscription(Student student);
    }
}