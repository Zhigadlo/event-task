﻿using Entities;

namespace Contracts.Repositories
{
    public interface IEventRepository
    {
        IQueryable<Event> GetAllEventAsync(bool trackChanges);
        Event? GetEventAsync(int id, bool trackChanges);
        void CreateEvent(Event @event);
        void DeleteEvent(Event @event);
        void UpdateEvent(Event @event);
    }
}