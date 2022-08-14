using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    private Animator anim;
    private int health = 5;
    private bool canDamage;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        canDamage = true;
    }

    IEnumerator waitForDamege()
    {
        yield return new WaitForSeconds(2f);
        canDamage = true;
    }

    

    private void OnTriggerEnter2D(Collider2D target)
    {
        if(canDamage)
        {
            if (target.tag == MyTags.BULLET_TAG)
            { 
                health--;
                canDamage = false;
                if (health == 0)
                {
                    GetComponent<BossScript>().DeactivateBossScript();
                    anim.Play("BossDead");
                    StartCoroutine(DeadBoss());
                }
            }
            StartCoroutine(waitForDamege());
        }
    }
    IEnumerator DeadBoss()
    {
        yield return new WaitForSeconds(5f);
        gameObject.SetActive(false);
    }
}
