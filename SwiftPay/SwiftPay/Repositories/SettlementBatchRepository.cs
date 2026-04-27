using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SwiftPay.Repositories.Interfaces;
using SwiftPay.Models;
using SwiftPay.Configuration;

namespace SwiftPay.Repositories
{
    public class SettlementBatchRepository : ISettlementBatchRepository
    {
        private readonly AppDbContext _context;

        public SettlementBatchRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<SettlementBatch> CreateAsync(SettlementBatch batch)
        {
            _context.SettlementBatches.Add(batch);
            await _context.SaveChangesAsync();
            return batch;
        }

        public async Task<SettlementBatch> GetByIdAsync(int id)
        {
            return await _context.SettlementBatches.FindAsync(id);
        }

        public async Task<IEnumerable<SettlementBatch>> GetAllAsync()
        {
            return await _context.SettlementBatches.ToListAsync();
        }

        public async Task<SettlementBatch> UpdateAsync(SettlementBatch batch)
        {
            _context.SettlementBatches.Update(batch);
            await _context.SaveChangesAsync();
            return batch;
        }
    }
}