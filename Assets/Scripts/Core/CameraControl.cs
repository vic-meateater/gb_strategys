using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour
{
	[SerializeField] private Transform startPoint;

	[SerializeField] private float _speed = 5;
	[SerializeField] private float _rotationSpeed = 3;
	[SerializeField] private float _scrollWheelSpeed = 3;

	[SerializeField] private float _rotationX = 55;
	[SerializeField] private float _maxHeight = 20;
	[SerializeField] private float _minHeight = 5;
	[SerializeField] private float _rotationLimit = 240;

	private KeyCode _left = KeyCode.A;
	private KeyCode _right = KeyCode.D;
	private KeyCode _up = KeyCode.W;
	private KeyCode _down = KeyCode.S;
	private KeyCode _rotationCameraLeft = KeyCode.Q;
	private KeyCode _rotationCameraRight = KeyCode.E;

	private float _minX = -5;
	private float _maxX = 55;
	private float _minZ = 9;
	private float _maxZ= 55;

	private float _camRotation;
	private float _height;
	private float _currentHeight;
	private float x, y;

	void Start()
	{
		_height = (_maxHeight + _minHeight) / 2;
		_currentHeight = _height;
		_camRotation = _rotationLimit / 2;
		transform.position = new Vector3(startPoint.position.x, _height, startPoint.position.z);
	}

	void Update()
	{
		if (Input.GetKey(_left)) x = -1; else if (Input.GetKey(_right)) x = 1; else x = 0;
		if (Input.GetKey(_down)) y = -1; else if (Input.GetKey(_up)) y = 1; else y = 0;

		if (Input.GetKey(_rotationCameraRight)) _camRotation += _rotationSpeed; else if (Input.GetKey(_rotationCameraLeft)) _camRotation -= _rotationSpeed;
		_camRotation = Mathf.Clamp(_camRotation, 0, _rotationLimit);

		if (Input.GetAxis("Mouse ScrollWheel") > 0)
		{
			if (_height < _maxHeight) _currentHeight--;
		}
		if (Input.GetAxis("Mouse ScrollWheel") < 0)
		{
			if (_height > _minHeight) _currentHeight++;
		}

		_currentHeight = Mathf.Clamp(_currentHeight, _minHeight, _maxHeight);
		_height = Mathf.Lerp(_height, _currentHeight, _scrollWheelSpeed * Time.deltaTime);

		Vector3 direction = new Vector3(x, y, 0);
		transform.Translate(direction * _speed * Time.deltaTime);
		transform.position = new Vector3(Mathf.Clamp(transform.position.x, _minX,_maxX), _height, Mathf.Clamp(transform.position.z, _minZ, _maxZ));
		transform.rotation = Quaternion.Euler(_rotationX, _camRotation, 0);
	}
}