using Contracts.Repositories;

namespace Contracts.Managers
{
    public interface IRepositoryManager
    {
        ISpeakerRepository Speaker { get; }
        IEventRepository Event { get; }
    }
}
