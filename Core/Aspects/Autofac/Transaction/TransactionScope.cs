using System;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors.Autofac;

namespace Core.Aspects.Autofac.Transaction
{
    public class TransactionScope : MethodInterception
    {
        public override void Intercept(IInvocation invocation)
        {
            using (System.Transactions.TransactionScope transactionScope = new System.Transactions.TransactionScope())
            {
                try
                {
                    invocation.Proceed();
                    transactionScope.Complete();
                }
                catch (System.Exception)
                {
                    transactionScope.Dispose();
                    throw;
                }
            }

        }
    }
}