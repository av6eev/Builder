using System;
using UnityEngine;

namespace Player
{
    public class PlayerModel
    {
        public event Action<Vector3> OnChangePosition; 
        public Vector3 Position;

        public void UpdatePosition(Vector3 newPosition)
        {
            OnChangePosition?.Invoke(newPosition);
        }
    }
}