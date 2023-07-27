using UnityEngine;

public class RayVision : MonoBehaviour
{

    #region Fields

    [SerializeField] private LayerMask _mask;
    [SerializeField] private float _speedRotation = 1.0f;
    [SerializeField] private float _distanceVision = 30.0f;

    [SerializeField] private Light _light;
    private Transform _target;
    private float _startOffset = 0.5f;
    private GameObject _boss;

    #endregion


    #region UnityMethods

    private void Start()
    {
        _boss = GameObject.FindGameObjectWithTag("Boss");
    }

    void FixedUpdate()
    {
        _target = _boss.transform;

        var color = Color.red;
        RaycastHit hit;

        var startRaycasstPosition = CalculateOffSet(transform.position);
        var directionToPlayer = CalculateOffSet(_target.position) - startRaycasstPosition;

        var rayCast = Physics.Raycast(startRaycasstPosition, directionToPlayer, out hit, _distanceVision, _mask);

        if (rayCast)
        {
            print(hit.collider.gameObject.name);
            if (hit.collider.gameObject.CompareTag("Boss"))
            {
                color = Color.green;
                print(hit.collider.gameObject.tag);
                if (_light.intensity < 50) _light.intensity++;
            }
        }
        if (color == Color.red && _light.intensity > 0) { _light.intensity--; }
        var _direction = directionToPlayer.normalized * _distanceVision;
        Debug.DrawRay(startRaycasstPosition, _direction, color);

        transform.rotation = Quaternion.LookRotation(_direction);
    }
    #endregion


    #region Methods 

    private Vector3 CalculateOffSet(Vector3 position)
    {
        position.y += _startOffset;
        return position;
    }

    #endregion
}