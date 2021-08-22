﻿using System;
using UnityEngine;

namespace Player
{
    public class PlayerModel
    {
        public event Action<Vector3> OnChangePosition;
        public event Action<Vector3> OnLookAt;
        
        public Vector3 Position;
        public float MousePositionX;
        public float MousePositionY;
        
        public readonly float Speed = 2f;
        public float CurrentVelocity = 0f;
        public readonly float MaxWalkVelocity = 4f;
        public readonly float MaxRunVelocity = 8f;

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