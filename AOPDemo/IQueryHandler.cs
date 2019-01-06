using System;
namespace AOPDemo
{
    public interface IQueryHandler<TQuery, TResult>
    {
        TResult Handle(TQuery query);
    }
}
