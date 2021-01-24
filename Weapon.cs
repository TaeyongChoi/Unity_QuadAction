using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public enum Type { Melee, Range };
    public Type type;
    public int damage;
    public float rate;
    public BoxCollider meleeArea;
    public TrailRenderer trailEffect;

    public void Use()
    {
        if(type == Type.Melee)
        {
            StopCoroutine("Swing");
            StartCoroutine("Swing");
        }
    }

    /* 
     * �Ϲ� �Լ�
     * Use() ���� ��ƾ-> Swing() �����ƾ -> Use() ���� ��ƾ (��������)
     * �ڷ�ƾ �Լ�
     * Use() ���� ��ƾ + Swing() �ڷ�ƾ(IEnumerator)
     * yeild Ű���带 ���� �� ����Ͽ� �ð��� ���� �ۼ� ���� 
     */

    IEnumerator Swing()
    {
        yield return new WaitForSeconds(0.1f);
        meleeArea.enabled = true;
        trailEffect.enabled = true;

        yield return new WaitForSeconds(0.3f);
        meleeArea.enabled = false;

        yield return new WaitForSeconds(0.3f);
        trailEffect.enabled = false;
    }
}
