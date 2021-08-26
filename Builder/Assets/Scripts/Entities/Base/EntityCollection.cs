using System.Collections.Generic;

namespace Entities.Base
{
    public class EntityCollection
    {
        private readonly IList<IEntity> _entities = new List<IEntity>();

        public void Add(IEntity entity)
        {
            _entities.Add(entity);
        }

        public void Remove(IEntity entity)
        {
            _entities.Remove(entity);
        }

        public void Clear()
        {
            _entities.Clear();
        }
    }
}