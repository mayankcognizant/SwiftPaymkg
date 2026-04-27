using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SwiftPay.Repositories.Interfaces;
using SwiftPay.Models;
using SwiftPay.Constants.Enums;
using SwiftPay.Configuration;

namespace SwiftPay.Repositories
{
    public class ReconciliationRepository : IReconciliationRepository
    {
        private readonly AppDbContext _context;

        public ReconciliationRepository(AppDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Persist a new reconciliation record to the database.
        /// </summary>
        public async Task<ReconciliationRecord> CreateAsync(ReconciliationRecord record)
        {
            _context.ReconciliationRecords.Add(record);
            await _context.SaveChangesAsync();
            return record;
        }

        /// <summary>
        /// Retrieve a reconciliation record by id.
        /// </summary>
        public async Task<ReconciliationRecord> GetByIdAsync(int id)
        {
            return await _context.ReconciliationRecords.FindAsync(id);
        }

        /// <summary>
        /// Retrieve all reconciliation records.
        /// </summary>
        public async Task<IEnumerable<ReconciliationRecord>> GetAllAsync()
        {
            return await _context.ReconciliationRecords.ToListAsync();
        }

        /// <summary>
        /// Query reconciliation records by result (Matched/Mismatched).
        /// </summary>
        public async Task<IEnumerable<ReconciliationRecord>> GetByResultAsync(Result result)
        {
            return await _context.ReconciliationRecords.Where(r => r.Result == result).ToListAsync();
        }

        /// <summary>
        /// Query reconciliation records filtered by reference type.
        /// </summary>
        public async Task<IEnumerable<ReconciliationRecord>> GetByReferenceTypeAsync(ReferenceType type)
        {
            return await _context.ReconciliationRecords.Where(r => r.ReferenceType == type).ToListAsync();
        }

        /// <summary>
        /// Update an existing reconciliation record and persist changes.
        /// </summary>
        public async Task<ReconciliationRecord> UpdateAsync(ReconciliationRecord record)
        {
            _context.ReconciliationRecords.Update(record);
            await _context.SaveChangesAsync();
            return record;
        }
    }
}