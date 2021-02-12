using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour
{
    public Transform target;
    public float orbitspeed;
    Vector3 offset;

    void Start()
    {
        offset = transform.position - target.position;
        //RotateAround()�� ��ǥ�� �����̸� �ϱ׷����� ����������
    }

    void Update()
    {
        transform.position = target.position + offset;
        transform.RotateAround(target.position, Vector3.up, orbitspeed * Time.deltaTime);
        offset = transform.position - target.position;
    }
}
