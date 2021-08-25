using System.Collections.Generic;
using UnityEngine;

namespace Utilities
{
    public class FixedSystemEngine : ISystem
    {
        private readonly Dictionary<SystemTypes, ISystem> _systems = new Dictionary<SystemTypes, ISystem>();

        public void Update(float deltaTime)
        {
            foreach (var system in _systems.Values)
            {
                system.Update(deltaTime);
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
    }
}