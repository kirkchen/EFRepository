using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFRepository.Hooks
{
    /// <summary>
    /// NestedDataPostUpdateHook
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <seealso cref="EFRepository.Hooks.IPreUpdateHook{TEntity}" />
    public class NestedDataPreUpdateHook<TEntity> : IPreUpdateHook<TEntity> where TEntity : class
    {
        /// <summary>
        /// Executes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="context">The context.</param>
        public void Execute(TEntity entity, HookContext context)
        {
            var dbContext = context.DbContext;

            //// Set children state
            this.SetEntityState(entity, dbContext);
        }

        /// <summary>
        /// Sets the state of the entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="dbContext">The database context.</param>
        private void SetEntityState(object entity, DbContext dbContext)
        {
            var datatype = entity.GetType();

            TypeDescriptor.AddProvider(new AssociatedMetadataTypeTypeDescriptionProvider(datatype), datatype);
            var properties = TypeDescriptor.GetProperties(datatype);

            foreach (PropertyDescriptor property in properties)
            {
                var isChildList = property.PropertyType.GetInterfaces()
                                                       .Any(t => t.IsGenericType
                                                                 && t.GetGenericTypeDefinition() == typeof(IEnumerable<>));
                isChildList = isChildList && property.PropertyType.IsGenericType;
                if (!isChildList)
                {
                    continue;
                }

                var childType = property.PropertyType.GenericTypeArguments[0];
                var children = property.GetValue(entity) as IEnumerable;
                if (children == null)
                {
                    continue;
                }

                var childSet = dbContext.Set(childType);
                foreach (var child in children)
                {
                    this.SetEntityState(child, dbContext);                    

                    var idProperty = childType.GetProperty("Id");
                    var idValue = idProperty.GetValue(child);

                    var childEntry = dbContext.Entry(child);                                        
                    if (idValue == null || idValue.Equals(Activator.CreateInstance(idProperty.PropertyType)))
                    {                        
                        childEntry.State = EntityState.Added;
                    }
                    else
                    {
                        childSet.Attach(child);
                        childEntry.State = EntityState.Modified;
                    }
                }
            }
        }
    }
}
