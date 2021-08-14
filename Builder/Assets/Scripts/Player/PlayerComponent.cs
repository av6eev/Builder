using UnityEngine;

namespace Player
{
    public class PlayerComponent : MonoBehaviour
    {
        public CharacterController CharacterController;
        
        public void ChangePosition(Vector3 position)
        {
            transform.position = position;
        }
    }
}