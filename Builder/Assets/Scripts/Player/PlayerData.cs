using System;
using UnityEngine;

namespace Player
{
    [CreateAssetMenu(fileName = "New Player Data", menuName = "Player Data", order = 51)]
    public class PlayerData : ScriptableObject
    {
        [Header("Velocity")]
        public float Speed = 5f;
        public float CurrentVelocity = 0f;
        public float MaxWalkVelocity = 4f;
        public float MaxRunVelocity = 8f;
        public float MovementMultiplier = 7f;
        public float AirMultiplier = 0.2f;
        
        [Header("Jump")]
        public float JumpForce = 1.2f;
        public float GroundDrag = 6f;
        public float AirDrag = 2.4f;
    }
}