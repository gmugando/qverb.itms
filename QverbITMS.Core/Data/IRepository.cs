﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace QverbITMS.Core.Data
{
    /// <summary>
    /// Repository
    /// </summary>
    public partial interface IRepository<T> where T : BaseEntity
    {
        /// <summary>
        /// Returns the queryable entity set for the given type {T}.
        /// </summary>
        IQueryable<T> Table { get; }

        /// <summary>
        /// Returns an untracked queryable entity set for the given type {T}.
        /// The entities returned will not be cached in the object context thus increasing performance.
        /// </summary>
        IQueryable<T> TableUntracked { get; }

        /// <summary>
        /// Creates a new instance of an entity of type {T}
        /// </summary>
        /// <returns>The new entity instance.</returns>
        T Create();

        /// <summary>
        /// Gets an entity by id from the database or the local change tracker.
        /// </summary>
        /// <param name="id">The id of the entity. This can also be a composite key.</param>
        /// <returns>The resolved entity</returns>
        T GetById(object id);

        /// <summary>
        /// Marks the entity instance to be saved to the store.
        /// </summary>
        /// <param name="entity">An entity instance that should be saved to the database.</param>
        /// <remarks>Implementors should delegate this to the current <see cref="IDbContext" /></remarks>
        void Insert(T entity);

        /// <summary>
        /// Marks multiple entities to be saved to the store.
        /// </summary>
        /// <param name="entities">The list of entity instances to be saved to the database</param>
        /// <param name="batchSize">The number of entities to insert before saving to the database (if <see cref="AutoCommitEnabled"/> is true)</param>
        void InsertRange(IEnumerable<T> entities, int batchSize = 100);

        /// <summary>
        /// Marks the changes of an existing entity to be saved to the store.
        /// </summary>
        /// <param name="entity">An instance that should be updated in the database.</param>
        /// <remarks>Implementors should delegate this to the current <see cref="IDbContext" /></remarks>
        void Update(T entity);

        /// <summary>
        /// Marks an existing entity to be deleted from the store.
        /// </summary>
        /// <param name="entity">An entity instance that should be deleted from the database.</param>
        /// <remarks>Implementors should delegate this to the current <see cref="IDbContext" /></remarks>
        void Delete(T entity);

        /// <summary>
        /// Instructs the repository to eager load entities that may be in the type's association path.
        /// </summary>
        /// <param name="query">A previously created query object which the expansion should be applied to.</param>
        /// <param name="path">
        /// The path of the child entities to eager load.
        /// Deeper paths can be specified by separating the path with dots.
        /// </param>
        /// <returns>A new query object to which the expansion was applied.</returns>
        IQueryable<T> Expand(IQueryable<T> query, string path);

        /// <summary>
        /// Instructs the repository to eager load entities that may be in the type's association path.
        /// </summary>
        /// <param name="query">A previously created query object which the expansion should be applied to.</param>
        /// <param name="path">The path of the child entities to eager load.</param>
        /// <returns>A new query object to which the expansion was applied.</returns>
        IQueryable<T> Expand<TProperty>(IQueryable<T> query, Expression<Func<T, TProperty>> path);

        /// <summary>
        /// Gets a value indicating whether the given entity was modified since it has been attached to the context
        /// </summary>
        /// <param name="entity">The entity to check</param>
        /// <returns><c>true</c> if the entity was modified, <c>false</c> otherwise</returns>
        bool IsModified(T entity);

        /// <summary>
        /// Gets a list of modified properties for the specified entity
        /// </summary>
        /// <param name="entity">The entity instance for which to get modified properties for</param>
        /// <returns>
        /// A dictionary, where the key is the name of the modified property
        /// and the value is its ORIGINAL value (which was tracked when the entity
        /// was attached to the context the first time)
        /// Returns an empty dictionary if no modification could be detected.
        /// </returns>
        IDictionary<string, object> GetModifiedProperties(T entity);

        /// <summary>
        /// Returns the data context associated with the repository.
        /// </summary>
        /// <remarks>
        /// The context is likely shared among multiple repository types.
        /// So committing data or changing configuration also affects other repositories. 
        /// </remarks>
        IDbContext Context { get; }

        /// <summary>
        /// Gets or sets a value indicating whether database write operations
        /// such as insert, delete or update should be committed immediately.
        /// </summary>
        bool AutoCommitEnabled { get; set; }
    }
}
