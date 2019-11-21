
using Castle.DynamicProxy;
using Core.Utilities.Interceptors.Autofac;

namespace Core.Utilities.Interceptors.Autofac
{
    public class MethodInterception : MethodInterceptionBaseAttribute
    {
        protected virtual void OnBefore(IInvocation invocation)
        {

        }
        protected virtual void OnAfter(IInvocation invocation)
        {

        }
        protected virtual void OnException(IInvocation invocation)
        {

        }
        protected virtual void OnSuccess(IInvocation invocation)
        {

        }
        public override void Intercept(IInvocation invocation)
        {
            var isSuccess = true;

            OnBefore(invocation);
            try
            {
                invocation.Proceed();
            }
            catch (System.Exception)
            {
                isSuccess = false;
                OnException(invocation);
            }
            finally
            {
                if (isSuccess)
                {
                    OnSuccess(invocation);
                }
            }
            OnAfter(invocation);
        }
    }
}