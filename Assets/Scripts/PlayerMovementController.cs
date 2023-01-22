using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    private float _horizontalValue;

    public float HorizontalValue {
        get { return _horizontalValue; }
    }
    
    [SerializeField] private float _forwardSpeed;
    [SerializeField] private float _horizontalSpeed;
    [SerializeField] private float _horizontalLimit;
    private float _newPositionX;

    void Update()
    {
        PlayerHorizontalInput();
        PlayerForwardMovement();
        PlayerHorizontalMovement();
    }

    private void PlayerHorizontalInput() {
        if (Input.GetMouseButton(0))
        {
            _horizontalValue = Input.GetAxis("Mouse X");
        }
        else
        {
            _horizontalValue = 0;
        }
    }

    private void PlayerForwardMovement() {
        transform.Translate(Vector3.down * _forwardSpeed * Time.deltaTime);
    }

    private void PlayerHorizontalMovement() {
        _newPositionX = transform.position.x + HorizontalValue * _horizontalSpeed * Time.deltaTime;
        _newPositionX = Mathf.Clamp(_newPositionX, -_horizontalLimit, _horizontalLimit);
        transform.position = new Vector3(_newPositionX, transform.position.y, transform.position.z);
    }
}
