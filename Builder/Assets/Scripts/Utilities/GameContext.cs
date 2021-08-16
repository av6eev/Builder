using InputManager;
using Player;
using UnityEngine.InputSystem;

namespace Utilities
{
    public class GameContext
    {
        public GlobalContainer GlobalContainer { get; set; }

        public PlayerModel PlayerModel { get; set; }
        public InputModel InputModel { get; set; }
        
        public SystemCollection SystemCollection { get; set; }
        public ControllerCollection ControllerCollection { get; set; }
    }
}