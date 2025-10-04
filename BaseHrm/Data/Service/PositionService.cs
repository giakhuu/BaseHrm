using AutoMapper;
using BaseHrm.Data.DTO;
using BaseHrm.Data.Models;
using BaseHrm.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseHrm.Data.Service
{
    public class PositionService : IPositionService
    {
        private readonly IPositionRepository _repo;
        private readonly IMapper _mapper;

        public PositionService(IPositionRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<List<PositionDto>> GetAllAsync(CancellationToken ct = default)
        {
            var list = await _repo.GetAllAsync(ct);
            var dtos = _mapper.Map<List<PositionDto>>(list);
            for (int i = 0; i < list.Count; i++)
            {
                dtos[i].EmployeeCount = list[i].Employees.Count;
            }
            return dtos;
        }

        public async Task<PositionDto?> GetByIdAsync(int id, CancellationToken ct = default)
        {
            var pos = await _repo.GetByIdAsync(id, ct);
            if (pos == null) return null;
            var dto = _mapper.Map<PositionDto>(pos);
            dto.EmployeeCount = pos.Employees.Count;
            return dto;
        }

        public async Task<PositionDto> CreateAsync(CreatePositionDto dto, CancellationToken ct = default)
        {
            var ent = _mapper.Map<Position>(dto);
            await _repo.AddAsync(ent, ct);
            await _repo.SaveChangesAsync(ct);
            return _mapper.Map<PositionDto>(ent);
        }

        public async Task<bool> UpdateAsync(UpdatePositionDto dto, CancellationToken ct = default)
        {
            var existing = await _repo.GetByIdAsync(dto.PositionId, ct);
            if (existing == null) return false;
            _mapper.Map(dto, existing);
            await _repo.UpdateAsync(existing, ct);
            await _repo.SaveChangesAsync(ct);
            return true;
        }

        public async Task<bool> DeleteAsync(int id, CancellationToken ct = default)
        {
            var existing = await _repo.GetByIdAsync(id, ct);
            if (existing == null) return false;
            await _repo.DeleteAsync(existing, ct);
            await _repo.SaveChangesAsync(ct);
            return true;
        }
    }
}
