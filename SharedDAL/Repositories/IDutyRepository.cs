using SharedDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedDAL.Repositories
{
    public interface IDutyRepository
    {
        Task<IEnumerable<Duty>> GetAllDutiesAsync();
        Task<Duty> GetDutyByIdAsync(int id);
        Task AddDutyAsync(Duty task);
        Task UpdateDutyAsync(Duty task);
        Task DeleteDutyAsync(int id);
    }
}
