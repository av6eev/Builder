using CameraManager;
using Player;
using Player.Systems;
using UnityEngine;
using Utilities;

public class StartController : MonoBehaviour
{
    [SerializeField] private GlobalContainer _container;
    private readonly GameContext _context = new GameContext();
    
    private readonly ControllerCollection _controllerCollection = new ControllerCollection();
    private readonly SystemCollection _systemCollection = new SystemCollection();
    private readonly StepCollection _stepCollection = new StepCollection();

    void Start()
    {
        _context.GlobalContainer = _container;

        _stepCollection.Execute(_context, _controllerCollection, _context.GlobalContainer);

        _systemCollection.Add(SystemTypes.PlayerMovementSystem, new PlayerMovementSystem(_context));
        _systemCollection.Add(SystemTypes.PlayerPhysicsSystem, new PlayerPhysicsSystem(_context));
        _systemCollection.Add(SystemTypes.CameraMovementSystem, new CameraMovementSystem(_context));
        
        _controllerCollection.Activate();    
    }

    void Update()
    {
        _systemCollection.Update(Time.deltaTime);
    }
}
