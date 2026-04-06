using Microsoft.EntityFrameworkCore;
using SmartHealthcare.API.Data;
using SmartHealthcare.API.Repositories.Interfaces;
using SmartHealthcare.Core.Models;

namespace SmartHealthcare.API.Repositories
{
    public class BillRepository : IBillRepository
    {
        private readonly AppDbContext _db;
        public BillRepository(AppDbContext db) { _db = db; }

        private IQueryable<Bill> WithIncludes() =>
            _db.Bills
                .Include(b => b.Appointment)
                    .ThenInclude(a => a.Patient)
                .Include(b => b.Appointment)
                    .ThenInclude(a => a.Doctor);

        public async Task<IEnumerable<Bill>> GetAllAsync() =>
            await WithIncludes().ToListAsync();

        public async Task<Bill?> GetByIdAsync(int id) =>
            await WithIncludes().FirstOrDefaultAsync(b => b.Id == id);

        public async Task<Bill?> GetByAppointmentAsync(int appointmentId) =>
            await WithIncludes().FirstOrDefaultAsync(b => b.AppointmentId == appointmentId);

        public async Task<Bill> CreateAsync(Bill bill)
        {
            _db.Bills.Add(bill);
            await _db.SaveChangesAsync();
            return bill;
        }
public async Task<IEnumerable<Bill>> GetByPatientAsync(int patientId) =>
    await WithIncludes()
        .Where(b => b.Appointment.PatientId == patientId)
        .ToListAsync();
        public async Task<Bill?> UpdateStatusAsync(int id, string status)
        {
            var bill = await _db.Bills.FindAsync(id);
            if (bill == null) return null;
            bill.Status = status;
            if (status == "Paid") bill.PaidAt = DateTime.UtcNow;
            await _db.SaveChangesAsync();
            return bill;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var bill = await _db.Bills.FindAsync(id);
            if (bill == null) return false;
            _db.Bills.Remove(bill);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}