using PaymentContext.Shared.Commands;

namespace PaymentContext.Shared.Handlers
{
    public interface IHandler<T> where T : Icommand
    {
        IcommandResult Handle(T command);
    }
}