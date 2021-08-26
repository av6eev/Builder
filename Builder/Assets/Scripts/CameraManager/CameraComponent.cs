using System;
using UnityEngine;

namespace CameraManager
{
    public class CameraComponent : MonoBehaviour
    {
        [SerializeField] public bool LockCursor = true;
        [NonSerialized] public Vector3 Forward;
        [NonSerialized] public Vector3 Right;
        public Transform Camera;
    }
}