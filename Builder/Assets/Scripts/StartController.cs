using Player;
using UnityEngine;
using Utilities;

public class StartController : MonoBehaviour
{
    private readonly GameContext _context = new GameContext();
    private readonly GlobalContainer _container = new GlobalContainer();
    
    private readonly ControllerCollection _controllerCollection = new ControllerCollection();
    private readonly StepCollection _stepCollection = new StepCollection();
    
    void Start()
    {
        _context.GlobalContainer = _container;
        
        _stepCollection.Add(new PlayerStep());        
        _stepCollection.Execute(_context, _controllerCollection, _container);
        
        _controllerCollection.Activate();    
    }

    void Update()
    {
    }
}
