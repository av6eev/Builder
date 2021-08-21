using Player;
using UnityEngine;
using Utilities;

namespace CameraManager
{
    public class CameraFollowSystem : ISystem
    {
        private readonly GameContext _context;

        public CameraFollowSystem(GameContext context)
        {
            _context = context;
        }
        
        public void Update(float deltaTime)
        {
            // var cameraComponent = _context.GlobalContainer.CameraComponent;
            // var cameraModel = _context.CameraModel;
            //
            // if (cameraComponent.Target == null)
            // {
            //     Debug.LogWarning("Missing target ref");
            // }
            //
            // if (cameraModel.OffsetPositionSpace == Space.Self)
            // {
            //     cameraComponent.transform.position = cameraComponent.Target.TransformPoint(cameraModel.OffsetPosition);
            // }
            // else
            // {
            //     cameraComponent.transform.position = cameraComponent.Target.position + cameraModel.OffsetPosition;
            // }
            //
            // if (cameraModel.IsLookAt)
            // {
            //     cameraComponent.transform.LookAt(cameraComponent.Target);
            // }
            // else
            // {
            //     cameraComponent.transform.rotation = cameraComponent.Target.rotation;
            // }
        }
    }
}