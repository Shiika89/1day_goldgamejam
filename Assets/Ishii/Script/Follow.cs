using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    private Vector3 _mouse;
    private Vector3 _target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _mouse = Input.mousePosition;
        _target = Camera.main.ScreenToWorldPoint(new Vector3(_mouse.x, _mouse.y, 10));
        //_target.y = transform.position.y;
        this.transform.position = _target;
    }
}
