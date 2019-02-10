using System.Threading.Tasks;

namespace CienciaArgentina.Microservices.Storage.Azure.TableStorage
{
	public interface IPersister<TDataRow>
	{
		/// <summary>
		/// Get a single entity by its key (partitionKey+rowKey)
		/// </summary>
		/// <param name="partitionKey">The PartitionKey.</param>
		/// <param name="rowKey">The RowKey</param>
		/// <returns>The entity if exists; null otherwise.</returns>
		Task<TDataRow> Get(string partitionKey, string rowKey);

		/// <summary>
		/// Save a new instance or, Update and existing one, to the table
		/// </summary>
		/// <param name="dataRow">The instance to be saved.</param>
		Task Add(TDataRow dataRow);

        /// <summary>
        /// Delete an entity instance by its key (partitionKey+rowKey)
        /// </summary>
        /// <param name="partitionKey">The PartitionKey.</param>
        /// <param name="rowKey">The RowKey</param>
        Task Delete(string partitionKey, string rowKey);

        /// <summary>
        ///  Delete an entity instance
        /// </summary>
        /// <param name="dataRow">The instance to be deleted.</param>
        Task Delete(TDataRow dataRow);

        /// <summary>
        /// Update an existing instance (previously uploaded)
        /// </summary>
        /// <param name="dataRow">The instance to be saved.</param>
        Task Update(TDataRow dataRow);
	}
}