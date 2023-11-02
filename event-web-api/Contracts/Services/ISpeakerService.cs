﻿using Entities.DatatTransferObjects;

namespace Contracts.Services
{
    public interface ISpeakerService
    {
        Task<SpeakerDto?> CreateAsync(SpeakerForCreationDto speakerForCreationDto, CancellationToken cancellationToken = default);
        Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);
        Task<IEnumerable<SpeakerDto>?> GetAllAsync(bool trackChanges);
        Task<SpeakerDto?> GetAsync(Guid id, bool trackChanges);
        Task UpdateAsync(SpeakerDto speakerForUpdateDto, CancellationToken cancellationToken = default);
    }
}