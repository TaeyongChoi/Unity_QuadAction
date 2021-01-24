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
     * 일반 함수
     * Use() 메인 루틴-> Swing() 서브루틴 -> Use() 메인 루틴 (교차실행)
     * 코루틴 함수
     * Use() 메인 루틴 + Swing() 코루틴(IEnumerator)
     * yeild 키워드를 여러 개 사용하여 시간차 로직 작성 가능 
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
