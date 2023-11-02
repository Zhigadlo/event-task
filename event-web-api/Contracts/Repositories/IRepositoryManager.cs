﻿namespace Contracts.Repositories
{
    public interface IRepositoryManager
    {
        ISpeakerRepository Speaker { get; }
        IEventRepository Event { get; }
    }
}
