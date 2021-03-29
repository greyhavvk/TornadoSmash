using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    #pragma warning disable 0649

    [Header("Variables")]

    [SerializeField] private bool _start = false;
    [SerializeField] private float _speed;
    [SerializeField] private float _sensitivity;
    [SerializeField] private float _deltaThreshold;
    [SerializeField] private float _minX;
    [SerializeField] private float _maxX;
    [SerializeField] private float _minZ;
    [SerializeField] private float _maxZ;

    [Header("References")]

    [SerializeField] private GameObject _vacuum;
    [SerializeField] private GameObject _center;

#pragma warning restore 0649

    public static MovementController movementController;

    private Rigidbody _rigidBodyPlayer;
    private Vector2 _currentTouchPosition;
    private float _finalX;
    private float _finalZ;
    private Vector2 _firstPosition;
    private float _currentSpeed;

    private void Awake()
    {
        movementController = this;
    }

    void Start()
    {
        AttachReferences();
        ResetValues();
    }

    void Update()
    {
        Movement();
    }

    private void Movement()
    {
        if (_start)
        {
            _vacuum.SetActive(true);
            _center.SetActive(true);
            HandleMovement();
        }
    }

    public void TriggerStart()
    {
        _start = true;
    }

    void AttachReferences()
    {
        _rigidBodyPlayer = GetComponent<Rigidbody>();
        _currentSpeed = _speed;
    }

    void ResetValues()
    {
        _rigidBodyPlayer.velocity = new Vector3(0f, _rigidBodyPlayer.velocity.y, 0f);
        _firstPosition = Vector2.zero;
        _finalX = 0f;
        _finalX = 0f;
        _currentTouchPosition = Vector2.zero;
    }

    void HandleMovement()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _firstPosition = Input.mousePosition;
        }

        if (Input.GetMouseButton(0))
        {
            _currentTouchPosition = Input.mousePosition;
            Vector2 touchDelta = (_currentTouchPosition - _firstPosition);

            if (_firstPosition == _currentTouchPosition)
            {
                _rigidBodyPlayer.velocity = new Vector3(0f, _rigidBodyPlayer.velocity.y, 0f);
            }

            _finalX = transform.position.x;
            _finalZ = transform.position.z;

            if (Mathf.Abs(touchDelta.x) >= _deltaThreshold)
            {
                _finalX = (transform.position.x + (touchDelta.x * _sensitivity));
            }
            if (Mathf.Abs(touchDelta.y) >= _deltaThreshold)
            {
                _finalZ = (transform.position.z + (touchDelta.y * _sensitivity));
            }

            _rigidBodyPlayer.position = new Vector3(_finalX, transform.position.y, _finalZ);
            _rigidBodyPlayer.position = new Vector3(Mathf.Clamp(_rigidBodyPlayer.position.x, _minX, _maxX), _rigidBodyPlayer.position.y, Mathf.Clamp(_rigidBodyPlayer.position.z, _minZ, _maxZ));

            _firstPosition = Input.mousePosition;
        }

        if (Input.GetMouseButtonUp(0))
        {
            ResetValues();
        }
    }
}
