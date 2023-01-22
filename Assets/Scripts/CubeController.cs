using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    [SerializeField] private StackController stackController;
    private Vector3 direction = Vector3.back;
    private bool _isStack = false;
    private RaycastHit hit;
    void Start()
    {
        stackController = GameObject.FindObjectOfType<StackController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Physics.Raycast(transform.position, direction, out hit, 1f))
        {
            if (!_isStack)
            {
                _isStack = !_isStack;
                stackController.IncreaseBlockStack(gameObject);
                SetDirection();
            }

            if (hit.transform.name == "ObstacleCube")
            {
                stackController.DecreaseBlock(gameObject);
            }
        }
    }
    private void SetDirection()
    {
        direction = Vector3.forward;
    }
}
