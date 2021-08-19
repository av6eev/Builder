using UnityEngine;
using Utilities;

namespace Player
{
    public class PlayerController : IController
    {
        private readonly PlayerModel _model;
        private readonly PlayerComponent _component;
        private readonly GameContext _context;

        public PlayerController(PlayerModel model, PlayerComponent component, GameContext context)
        {
            _model = model;
            _component = component;
            _context = context;
        }

        public void Deactivate()
        {
            _model.OnChangePosition -= ChangePosition;
            _model.OnLookAt -= LookAt;
        }

        public void Activate()
        {
            _model.OnChangePosition += ChangePosition;
            _model.OnLookAt += LookAt;
        }

        private void ChangePosition(Vector3 currentPosition)
        {
            _model.Position = currentPosition;
        }
        
        private void LookAt(Vector3 obj)
        {
            _component.transform.LookAt(obj);
        }
    }
}