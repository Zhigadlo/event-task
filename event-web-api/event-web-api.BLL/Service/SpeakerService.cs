using AutoMapper;
using Contracts.Repositories;
using Contracts.Services;
using Entities;
using Entities.DatatTransferObjects;
using Entities.Exceptions;
using event_web_api.BLL.Validation;

namespace event_web_api.BLL.Service
{
    public class SpeakerService : ISpeakerService
    {
        private IRepositoryManager _repositoryManager;
        private IMapper _mapper;
        private SpeakerValidator _validator;
        public SpeakerService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
            _validator = new SpeakerValidator();
        }
        public async Task<SpeakerDto?> CreateAsync(SpeakerForCreationDto speakerForCreationDto, CancellationToken cancellationToken = default)
        {
            var speaker = _mapper.Map<Speaker>(speakerForCreationDto);

            var result = await _validator.ValidateAsync(speaker, cancellationToken);
            if (!result.IsValid)
            {
                var message = string.Join(Environment.NewLine, result.Errors.Select(x => x.ErrorMessage));
                throw new EntityIsNotValidException(message);
            }

            await _repositoryManager.Speaker.CreateSpeakerAsync(speaker, cancellationToken);
            return _mapper.Map<SpeakerDto>(speaker);
        }

        public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            await _repositoryManager.Speaker.DeleteSpeakerAsync(id, cancellationToken);
        }

        public async Task<IEnumerable<SpeakerDto>?> GetAllAsync(bool trackChanges, CancellationToken cancellationToken = default)
        {
            return _mapper.Map<IEnumerable<SpeakerDto>?>(await _repositoryManager.Speaker.GetAllSpeakersAsync(trackChanges, cancellationToken));
        }

        public async Task<SpeakerDto?> GetAsync(Guid id, bool trackChanges, CancellationToken cancellationToken = default)
        {
            return _mapper.Map<SpeakerDto>(await _repositoryManager.Speaker.GetSpeakerAsync(id, trackChanges, cancellationToken));
        }

        public async Task UpdateAsync(SpeakerDto speakerForUpdateDto, CancellationToken cancellationToken = default)
        {
            var speaker = _mapper.Map<Speaker>(speakerForUpdateDto);

            var result = await _validator.ValidateAsync(speaker);
            if (!result.IsValid)
            {
                var message = string.Join(Environment.NewLine, result.Errors.Select(x => x.ErrorMessage));
                throw new EntityIsNotValidException(message);
            }

            await _repositoryManager.Speaker.UpdateSpeakerAsync(speaker);
        }
    }
}
