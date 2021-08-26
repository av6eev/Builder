using System.Collections.Generic;

namespace Entities.Base
{
    public interface IEntity
    {
        IReadOnlyList<Actions> ActionComponents { get; }
        Dictionary<Actions, IEntityBehaviour> Behaviours { get; }
    }
}