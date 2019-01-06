using System;
namespace AOPDemo
{
    public interface ICommandHandler<TCommand>
    {
        void Handle(TCommand command);
    }
}
