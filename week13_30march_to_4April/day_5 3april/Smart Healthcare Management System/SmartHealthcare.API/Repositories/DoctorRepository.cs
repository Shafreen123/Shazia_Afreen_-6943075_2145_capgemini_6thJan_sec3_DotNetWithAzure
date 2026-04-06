using Microsoft.EntityFrameworkCore;
using SmartHealthcare.API.Data;
using SmartHealthcare.API.Repositories.Interfaces;
using SmartHealthcare.Core.Models;

namespace SmartHealthcare.API.Repositories
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly AppDbContext _db;
        public DoctorRepository(AppDbContext db) { _db = db; }

        public async Task<IEnumerable<Doctor>> GetAllAsync() =>
            await _db.Doctors
                .Include(d => d.DoctorSpecializations).ThenInclude(ds => ds.Specialization)
                .ToListAsync();

        public async Task<Doctor?> GetByIdAsync(int id) =>
            await _db.Doctors
                .Include(d => d.DoctorSpecializations).ThenInclude(ds => ds.Specialization)
                .FirstOrDefaultAsync(d => d.Id == id);

        public async Task<IEnumerable<Doctor>> GetBySpecializationAsync(string specialization) =>
            await _db.Doctors
                .Include(d => d.DoctorSpecializations).ThenInclude(ds => ds.Specialization)
                .Where(d => d.DoctorSpecializations.Any(ds =>
                    ds.Specialization.Name.Contains(specialization)))
                .ToListAsync();

        public async Task<Doctor> CreateAsync(Doctor doctor)
        {
            _db.Doctors.Add(doctor);
            await _db.SaveChangesAsync();
            return doctor;
        }

        public async Task<Doctor?> UpdateAsync(int id, Doctor updated)
        {
            var d = await _db.Doctors.FindAsync(id);
            if (d == null) return null;
            d.FullName = updated.FullName; d.Email = updated.Email;
            d.Phone = updated.Phone; d.ExperienceYears = updated.ExperienceYears;
            await _db.SaveChangesAsync();
            return d;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var d = await _db.Doctors.FindAsync(id);
            if (d == null) return false;
            _db.Doctors.Remove(d);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}
