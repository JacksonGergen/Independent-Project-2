using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    public Vector3 camOffset = new Vector3(0f, 1f, -3.5f);
    private Transform _target;

    // Start is called before the first frame update
    void Start()
    {
        _target = GameObject.Find("Jammo_Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = _target.TransformPoint(camOffset);
        this.transform.LookAt(_target);
    }
}
