using UnityEngine;

namespace Player
{
    [CreateAssetMenu(fileName = "New Player Data", menuName = "Player Data", order = 51)]
    public class PlayerData : ScriptableObject
    {
        [Header("Velocity")]
        public float Speed = 5f;
        public float CurrentVelocity;
        public float MaxWalkVelocity = 4f;
        public float MaxRunVelocity = 6f;
        public float MovementMultiplier = 2f;
        public float AirMultiplier = 0.5f;
        
        [Header("Jump")]
        public float JumpForce = 1.3f;
        public float GroundDrag = 5f;
        public float AirDrag = 2.4f;
    }
}