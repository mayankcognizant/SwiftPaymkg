using System.Collections.Generic;
using System.Threading.Tasks;
using SwiftPay.DTOs.ReconciliationDTO;
using SwiftPay.Models;
using SwiftPay.Constants.Enums;

namespace SwiftPay.Services.Interfaces
{
	public interface IReconciliationService
	{
       
			/// <summary>
			/// Run reconciliation for the specified settlement batch and return generated records.
			/// </summary>
			/// <param name="batchId">Identifier of the settlement batch to reconcile.</param>
			Task<IEnumerable<ReconciliationRecord>> ReconcileBatchAsync(int batchId);

			/// <summary>
			/// Auto-reconcile a single reference and create a reconciliation record.
			/// </summary>
			/// <param name="type">Reference type (Remit or Instruction).</param>
			/// <param name="referenceId">Identifier of the reference to reconcile.</param>
			Task<ReconciliationRecord> AutoReconcileAsync(ReferenceType type, string referenceId);

			// --------------------------------------------------------
			// STANDARD CRUD & QUERIES
			// --------------------------------------------------------
			/// <summary>
			/// Create a reconciliation record from the provided DTO.
			/// </summary>
			Task<ReconciliationRecord> CreateAsync(CreateReconciliationDto dto);
			/// <summary>
			/// Update an existing reconciliation record according to the DTO.
			/// </summary>
			Task<ReconciliationRecord> UpdateAsync(UpdateReconciliationDto dto);
			/// <summary>
			/// Retrieve a reconciliation record by its numeric identifier.
			/// </summary>
			Task<ReconciliationRecord> GetByIdAsync(int id);
			/// <summary>
			/// Retrieve all reconciliation records.
			/// </summary>
			Task<IEnumerable<ReconciliationRecord>> GetAllAsync();
			/// <summary>
			/// Retrieve reconciliation records that are mismatched.
			/// </summary>
			Task<IEnumerable<ReconciliationRecord>> GetMismatchesAsync();
			/// <summary>
			/// Retrieve reconciliation records filtered by reference type.
			/// </summary>
			Task<IEnumerable<ReconciliationRecord>> GetByTypeAsync(ReferenceType type);
			/// <summary>
			/// Soft-delete or remove a reconciliation record.
			/// </summary>
			Task<bool> DeleteAsync(int id);
	}
}