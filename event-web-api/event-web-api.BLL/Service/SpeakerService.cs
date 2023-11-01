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

            var result = _validator.Validate(speaker);
            if (!result.IsValid)
            {
                var message = string.Join(Environment.NewLine, result.Errors.Select(x => x.ErrorMessage));
                throw new EntityIsNotValidException(message);
            }

            _repositoryManager.Speaker.CreateSpeaker(speaker);
            await _repositoryManager.SaveChangesAsync(cancellationToken);
            return _mapper.Map<SpeakerDto>(speaker);
        }

        public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var speakerForDelete = _repositoryManager.Speaker.GetSpeaker(id, true);
            if (speakerForDelete == null) 
            {
                throw new NotFoundException("Speaker with such id is not found");
            }

            _repositoryManager.Speaker.DeleteSpeaker(speakerForDelete);
            await _repositoryManager.SaveChangesAsync(cancellationToken);
        }

        public async Task<IEnumerable<SpeakerDto>?> GetAllAsync(bool trackChanges)
        {
            return await Task.FromResult(_mapper.Map<IEnumerable<SpeakerDto>>(_repositoryManager.Speaker.GetAllSpeaker(trackChanges)));
        }

        public async Task<SpeakerDto?> GetAsync(Guid id, bool trackChanges)
        {
            return await Task.FromResult(_mapper.Map<SpeakerDto>(_repositoryManager.Speaker.GetSpeaker(id, trackChanges)));
        }

        public async Task UpdateAsync(SpeakerDto speakerForUpdateDto, CancellationToken cancellationToken = default)
        {
            var speaker = _mapper.Map<Speaker>(speakerForUpdateDto);
            var result = _validator.Validate(speaker);
            if (!result.IsValid)
            {
                var message = string.Join(Environment.NewLine, result.Errors.Select(x => x.ErrorMessage));
                throw new EntityIsNotValidException(message);
            }

            _repositoryManager.Speaker.UpdateSpeaker(speaker);
            await _repositoryManager.SaveChangesAsync(cancellationToken);
        }
    }
}
