using System;
using System.Collections.Generic;
using System.Linq;

namespace EntityBuilder
{
    public class EntityBuilder<T>
    {
        private readonly Dictionary<Type, List<Func<T, object, T>>> _eventHandlers = new Dictionary<Type, List<Func<T, object, T>>>();

        protected void RegisterHandler<TEvent>(Func<T, TEvent, T> handler)
        {
            if (!_eventHandlers.TryGetValue(typeof(TEvent), out var handlers))
            {
                handlers = new List<Func<T, object, T>>();
                _eventHandlers.Add(typeof(TEvent), handlers);
            }

            handlers.Add((x, y) => handler(x, (TEvent)y));
        }

        protected T Apply(T currentState, object command)
        {

            if (!_eventHandlers.TryGetValue(command.GetType(), out var handlers))
                throw new InvalidOperationException("no handler registered");

            if (handlers.Count != 1)
                throw new InvalidOperationException("cannot send to more than one handler");

            var entity = handlers[0](currentState, command);
            return entity;
        }

        public T Apply(T currentState, IEnumerable<object> events)
        {
            return events.Aggregate(currentState, Apply);
        }
    }
}
