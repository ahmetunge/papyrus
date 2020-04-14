using System;
using Core.Extensions;
using Core.Utilities.IoC;
using Core.Utilities.Security.Identification;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Entities
{
    public class EntityBase<T>
    {
        public EntityBase()
        {
          
        }
        public T Id { get; set; }
        public Guid? InsertUserId { get; internal set; }
        public Guid? UpdateUserId { get; internal set; }
        public DateTime? InsertTime { get; internal set; }
        public DateTime? UpdateTime { get; internal set; }
        public int RowVersion { get; set; }
    }
}