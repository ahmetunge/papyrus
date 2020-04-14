using System;
using Core.Entities;
using Core.Utilities.Security.Identification;

namespace Core.Extensions
{
    public static class EnitityBaseExtensions
    {
        public static void UserAndDateForCreation(this EntityBase<Guid> entityBase)
        {

            entityBase.InsertUserId = UserIdentification.UserId;
            entityBase.InsertTime = DateTime.Now;
            entityBase.RowVersion = 0;

        }
        public static void UserAndDateForUpdate(this EntityBase<Guid> entityBase, int rowVersion)
        {
            entityBase.InsertUserId = UserIdentification.UserId;
            entityBase.InsertTime = DateTime.Now;
            entityBase.RowVersion = rowVersion++;
        }
    }
}