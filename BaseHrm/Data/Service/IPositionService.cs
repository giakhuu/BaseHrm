using BaseHrm.Data.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseHrm.Data.Service
{
    public interface IPositionService
    {
        Task<List<PositionDto>> GetAllAsync(CancellationToken ct = default);
        Task<PositionDto?> GetByIdAsync(int id, CancellationToken ct = default);
        Task<PositionDto> CreateAsync(CreatePositionDto dto, CancellationToken ct = default);
        Task<bool> UpdateAsync(UpdatePositionDto dto, CancellationToken ct = default);
        Task<bool> DeleteAsync(int id, CancellationToken ct = default);
    }
}
