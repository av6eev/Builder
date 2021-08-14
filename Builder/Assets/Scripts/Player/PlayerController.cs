﻿using UnityEngine;
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
        
        public void Activate()
        {
            _model.OnChangePosition += ChangePosition;
        }

        public void Deactivate()
        {
            _model.OnChangePosition -= ChangePosition;
        }
        
        private void ChangePosition(Vector3 newCoords)
        {
            var position = _component.transform.position + newCoords;
            
            _model.Position = position;
            _component.ChangePosition(position);
        }
    }
}