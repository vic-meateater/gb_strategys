using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UniRx;
using Zenject;

public class MouseInteractionsPresenter : MonoBehaviour
{
    [SerializeField] private EventSystem _eventSystem;
    [SerializeField] private Camera _camera;
    [SerializeField] private SelectableValue _selectedObject;

    [SerializeField] private Vector3Value _groundClicksRMB;
    [SerializeField] private AttackableValue _attackablesRMB;
    [SerializeField] private Transform _groundTransform;

    [Inject] private CommandCreatorBase<IMoveCommand> _mover;

    private Plane _groundPlane;

    private ISelecatable _previousSelectable;

    private void Start()
    {
        _groundPlane = new Plane(_groundTransform.up, 0);
    }

    private void Update()
    {
        if (!Input.GetMouseButtonUp(0) && !Input.GetMouseButton(1))
        {
            return;
        }
        if (_eventSystem.IsPointerOverGameObject())
        {
            return;
        }
        var ray = _camera.ScreenPointToRay(Input.mousePosition);
        var hits = Physics.RaycastAll(ray);
        if (Input.GetMouseButtonUp(0))
        {
            if (weHit<ISelecatable>(hits, out var selectable))
            {
                _selectedObject.SetValue(selectable);
                Debug.Log("WE HIT Selectable " + selectable);
            }
        }
        else
        {
            if (weHit<IAttackable>(hits, out var attackable))
            {
                _attackablesRMB.SetValue(attackable);
                Debug.Log("WE HIT Attackable");
            }
            else if (_groundPlane.Raycast(ray, out var enter))
            {
                Debug.Log("WE HIT GROUND");
                _groundClicksRMB.SetValue(ray.origin + ray.direction * enter);
            }
        }
    }

    private bool weHit<T>(RaycastHit[] hits, out T result) where T : class
    {
        result = default;
        if (hits.Length == 0)
        {
            return false;
        }
        result = hits
            .Select(hit => hit.collider.GetComponentInParent<T>())
            .Where(c => c != null)
            .FirstOrDefault();
        return result != default;
    }
}