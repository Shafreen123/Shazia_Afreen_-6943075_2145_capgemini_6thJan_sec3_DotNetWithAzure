using SmartHealthcare.Core.Models;

namespace SmartHealthcare.API.Repositories.Interfaces
{
    public interface IBillRepository
    {
        Task<IEnumerable<Bill>> GetAllAsync();
        Task<Bill?> GetByIdAsync(int id);
        Task<Bill?> GetByAppointmentAsync(int appointmentId);
        Task<Bill> CreateAsync(Bill bill);
        Task<Bill?> UpdateStatusAsync(int id, string status);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<Bill>> GetByPatientAsync(int patientId);
    }
}