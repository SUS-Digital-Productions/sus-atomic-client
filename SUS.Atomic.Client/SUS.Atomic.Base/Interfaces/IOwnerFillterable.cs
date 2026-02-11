using System;

namespace SUS.Atomic.Base.Interfaces
{
    /// <summary>
    /// Interface for endpoints that support filtering by owner.
    /// </summary>
    /// <typeparam name="Type">The type of the implementing endpoint.</typeparam>
    public interface IOwnerFilterable<Type> : IQueryable
    {
    }

    /// <summary>
    /// Legacy interface name kept for backward compatibility.
    /// Use <see cref="IOwnerFilterable{Type}"/> instead.
    /// </summary>
    /// <typeparam name="Type">The type of the implementing endpoint.</typeparam>
    [Obsolete("This interface has a typo in its name. Use IOwnerFilterable<Type> instead.")]
    public interface IOwnerFillterable<Type> : IOwnerFilterable<Type>
    {
    }
}
