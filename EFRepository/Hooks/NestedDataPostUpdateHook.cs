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
    /// <seealso cref="EFRepository.Hooks.IPostUpdateHook{TEntity}" />
    public class NestedDataPostUpdateHook<TEntity> : IPostUpdateHook<TEntity> where TEntity : class
    {
        /// <summary>
        /// Executes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="context">The context.</param>
        public void Execute(TEntity entity, HookContext context)
        {
            var datatype = typeof(TEntity);            

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
                foreach (var child in children)
                {
                    context.DbContext.Set(childType).Attach(child);

                    var childEntry = context.DbContext.Entry(child);
                    childEntry.State = EntityState.Modified;
                }
            }
        }
    }
}
