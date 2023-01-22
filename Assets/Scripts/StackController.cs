using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackController : MonoBehaviour
{
    public List<GameObject> _blockList = new List<GameObject>();
    private GameObject _lastBlockObject;
    void Start()
    {
        LastBlockObject();
    }

    public void IncreaseBlockStack(GameObject _gameObject) {
        transform.position = new Vector3(transform.position.x, transform.position.y + 2f, transform.position.z);
        _gameObject.transform.position = new Vector3(_lastBlockObject.transform.position.x, _lastBlockObject.transform.position.y - 2f, _lastBlockObject.transform.position.z);
        _gameObject.transform.SetParent(transform);
        _blockList.Add(_gameObject);
        LastBlockObject();
    }

    public void DecreaseBlock(GameObject _gameObject) {
        _gameObject.transform.parent = null;
        _blockList.Remove(_gameObject);
        LastBlockObject();
    }

    private void LastBlockObject() {
        _lastBlockObject = _blockList[_blockList.Count -1];
    }
    
}
