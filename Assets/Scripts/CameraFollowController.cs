using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowController : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;
    private Vector3 _offset;
    private Vector3 _newPosition;
    [SerializeField] private float _lerpValue;
    void Start()
    {
        _offset = transform.position - _playerTransform.position;
    }

    
    void LateUpdate()
    {
        CameraFollow();
    }

    private void CameraFollow() {
        _newPosition = Vector3.Lerp(transform.position, new Vector3(0f, _playerTransform.position.y, _playerTransform.position.z) + _offset, _lerpValue * Time.deltaTime);
        transform.position = _newPosition;
    }
}
