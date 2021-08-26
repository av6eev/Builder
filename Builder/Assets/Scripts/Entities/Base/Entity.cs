using System.Collections.Generic;

namespace Entities.Base
{
    public class Entity : IEntity
    {
        public IReadOnlyList<Actions> ActionComponents { get; protected set; }
        public Dictionary<Actions, IEntityBehaviour> Behaviours { get; protected set; } = new Dictionary<Actions, IEntityBehaviour>();
        
        public Entity(Actions[] actions, IEntityBehaviour[] behaviours)
        {
            ActionComponents = actions;

            foreach (var behaviour in behaviours)
            {
                Behaviours.Add(behaviour.Action, behaviour);
            }
        }

        protected Entity()
        {
            
        }
        
        public T GetBehaviour<T>(Actions action) where T : IEntityBehaviour
        {
            return (T)Behaviours[action];
        }
    }
}