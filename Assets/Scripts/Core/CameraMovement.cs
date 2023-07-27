using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private float _screenWidth = Screen.width;
    private float _screenHeight = Screen.height;
    private bool _camera;

    [SerializeField] private float _cameraSensative = 10;
    [SerializeField] private float _cameraSpeed = 1;

    private void Start()
    {
        _screenWidth = Screen.width;
        _screenHeight = Screen.height;
    }

    // Update is called once per frame
    private void Update()
    {
        Vector3 _cameraPosition = transform.position;

        if (Input.mousePosition.x <= _cameraSensative)
        {
            _cameraPosition.x -= Time.deltaTime * _cameraSpeed;
            _cameraPosition.z += Time.deltaTime * _cameraSpeed; 
        }    
        else if (Input.mousePosition.x <= _screenWidth - _cameraSensative)
        {
            _cameraPosition.x += Time.deltaTime * _cameraSpeed;
            _cameraPosition.z -= Time.deltaTime * _cameraSpeed;
        }
        else if (Input.mousePosition.y <= _cameraSensative)
        {
            _cameraPosition.x -= Time.deltaTime * _cameraSpeed;
            _cameraPosition.z -= Time.deltaTime * _cameraSpeed;
        }
        else if (Input.mousePosition.y <= _screenHeight - _cameraSensative)
        {
            _cameraPosition.x += Time.deltaTime * _cameraSpeed;
            _cameraPosition.z += Time.deltaTime * _cameraSpeed;
        }

        transform.position = _cameraPosition;
    }
}
