using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour
{
    public Transform target;
    public float orbitspeed;
    Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - target.position;
        //RotateAround()는 목표가 움직이면 일그러지는 단점이있음
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = target.position + offset;
        transform.RotateAround(target.position, Vector3.up, orbitspeed * Time.deltaTime);
        offset = transform.position - target.position;
    }
}
