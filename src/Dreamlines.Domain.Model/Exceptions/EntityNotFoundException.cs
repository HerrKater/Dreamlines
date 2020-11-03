using Dreamlines.Domain.Exceptions;
using Dreamlines.Domain.Extensions;
using System;
using System.ComponentModel;

namespace Dreamlines.Domain.Exceptions
{
    /// <summary>
    /// The entity with the given Id cannot be found
    /// </summary>
    public class EntityNotFoundException : DreamlinesException
    {
        public EntityNotFoundException(Type entityType,int id):base($"The entity({entityType.GetAttribute<DescriptionAttribute>()?.Description ?? entityType.Name}, id:{id}) does not exist.", null)
        {
        }
        public EntityNotFoundException(string userErrorMessage, Exception innerException) : base(userErrorMessage, innerException)
        {
        }
    }
}
