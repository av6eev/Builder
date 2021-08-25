using System.Collections.Generic;
using Player;
using UnityEngine;

namespace Utilities
{
    public class BaseSystemEngine : ISystem
    {
        private readonly Dictionary<SystemTypes, ISystem> _systems = new Dictionary<SystemTypes, ISystem>();

        public void Update(float deltaTime)
        {
            foreach (var system in _systems.Values)
            {
                system.Update(Time.deltaTime);
            }
        }

        public void Add(SystemTypes type, ISystem system)
        {
            _systems.Add(type, system);
        }

        public void Remove(SystemTypes type)
        {
            _systems.Remove(type);
        }

        public void Clear()
        {
            _systems.Clear();
        }

        public ISystem Get(SystemTypes type)
        {
            return _systems[type];
        }
    }
}