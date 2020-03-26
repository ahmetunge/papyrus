
using System;
using System.Threading.Tasks;
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
        protected virtual void OnException(IInvocation invocation, System.Exception ex)
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
                Type returnType = invocation.Method.ReturnType;

                if (returnType.IsGenericType && returnType.GetGenericTypeDefinition() == typeof(Task<>)
                || returnType.BaseType == typeof(Task))
                {
                    System.Threading.Tasks.Task task = (Task)invocation.ReturnValue;

                    if (task.Status == TaskStatus.Faulted)
                    {
                        throw task.Exception;
                    }
                }
            }
            catch (System.Exception ex)
            {
                isSuccess = false;
                OnException(invocation, ex);
                throw;
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