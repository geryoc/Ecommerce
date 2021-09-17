using Ecommerce.WebApi.Shared.Database;
using System;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce.WebApi.Shared.Web.ValidationAttributes
{
    public class EntityExistsAttribute : ValidationAttribute
    {
        public EntityExistsAttribute(Type entityType)
        {
            EntityType = entityType;
        }

        public Type EntityType { get; }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return ValidationResult.Success;
            }

            var entityId = (long)value;
            var databaseContext = (DatabaseContext)validationContext.GetService(typeof(DatabaseContext));
            var entity = databaseContext.Find(EntityType, entityId);

            if (entity != null)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult($"The {EntityType.Name} with Id='{entityId}' does not exist.");
            }
        }
    }
}
