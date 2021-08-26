using System;
using System.Collections.Generic;
using Entities;
using Entities.Base;
using Player.Behaviours;
using UnityEngine;

namespace Player
{
    public class PlayerModel : Entity
    {
        public event Action<Vector3> OnChangePosition;
        public event Action<Vector3> OnLookAt;
        
        public Vector3 Position;
        public float MousePositionX;
        public float MousePositionY;
        
        public bool IsGrounded;

        public PlayerModel()
        {
            ActionComponents = new[] { Actions.Move };
        }
        
        public void UpdatePosition(Vector3 newPosition)
        {
            OnChangePosition?.Invoke(newPosition);
        }

        public void LookAt(Vector3 hitPoint)
        {
            OnLookAt?.Invoke(hitPoint);
        }
    }
}