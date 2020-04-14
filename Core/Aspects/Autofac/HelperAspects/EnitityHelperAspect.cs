using System;
using Castle.DynamicProxy;
using Core.Entities;
using Core.Extensions;
using Core.Utilities.Interceptors.Autofac;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Aspects.Autofac.HelperAspects
{
    public class EnitityHelperAspect : MethodInterception
    {
        private IHttpContextAccessor _httpContextAccessor;
        public EnitityHelperAspect()
        {
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();
        }

        protected override void OnBefore(IInvocation invocation)
        {

            for (int i = 0; i < invocation.Arguments.Length; i++)
            {
                object value = invocation.Arguments[i];

                if (value.GetType().IsSubclassOf(typeof(EntityBase<Guid>)))
                {
                    var e = (EntityBase<Guid>)value;
                    // e.InsertTime = DateTime.Now;
                    // e.InsertUserId = _httpContextAccessor.GetUserId();
                }


            }


        }
    }
}