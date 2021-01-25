using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    /*
     * 빛이 여러개일때 화면에 따라 빛이 꺼지는 현상
     * Scene에서 사용할 수 있는 라이트가 제한되어 있어서 생기는 현상입니다
     * Edit - Project Settings - Quality - Pixel Light Count 에서 숫자를 올려줍니다
     * 추후 그래픽 품질이 낮아질수있습니다.
    */

    public enum Type { Ammo, Coin, Grenade, Heart, Weapon };
    public Type type;
    public int value;

    Rigidbody rigid;
    SphereCollider SphereCollider;

    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        SphereCollider = GetComponent<SphereCollider>();
        //Unity에서 GetComponent()는 첫번째 컴포넌트를 가져옴
    }

    void Update()
    {
        transform.Rotate(Vector3.up * 20 * Time.deltaTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Floor")
        {
            rigid.isKinematic = true;
            SphereCollider.enabled = false;
        }
    }
}
