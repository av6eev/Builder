using System;
using UnityEngine;

namespace Player
{
    public class PlayerModel
    {
        public event Action<Vector3> OnChangePosition; 
        
        [SerializeField] public float MoveSpeed = 5f;
        [SerializeField] public float JumpSpeed = 1f;
        [SerializeField] public float Gravity = 9.81f;
        
        public Vector3 Position;
        public float DirectionY;
        
        public void UpdatePosition(Vector3 newPosition)
        {
            OnChangePosition?.Invoke(newPosition);
        }
    }
}