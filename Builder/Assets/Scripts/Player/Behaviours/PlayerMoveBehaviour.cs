using Entities;
using Entities.Base;
using Utilities;

namespace Player.Behaviours
{
    public class PlayerMoveBehaviour : IController, IEntityBehaviour
    {
        private readonly GameContext _context;
        private readonly PlayerModel _model;
        public Actions Action { get; }

        public PlayerMoveBehaviour(GameContext context, PlayerModel model)
        {
            _context = context;
            _model = model;
        }
        
        public void Deactivate()
        {
            
        }

        public void Activate()
        {
                        
        }
    }
}