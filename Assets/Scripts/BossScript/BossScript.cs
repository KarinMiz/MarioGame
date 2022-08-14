using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    public GameObject stone;
    public Transform attackInstantiat;
    private Animator anim;
    private string coroutineName = "startAttack";

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    void Start()
    {
        StartCoroutine(coroutineName);
    }
    void Attack()
    {
        GameObject obj = Instantiate(stone, attackInstantiat.position, Quaternion.identity);
        obj.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-300, -700), 0f));
    }
    void BackToIdle()
    {
        anim.Play("BossIdle");
    }
    public void DeactivateBossScript()
    {
        StopCoroutine(coroutineName);
        enabled = false;
    }
    IEnumerator startAttack()
    {
        yield return new WaitForSeconds(Random.Range(2f, 5f));
        anim.Play("BossAttack");
        StartCoroutine(coroutineName);
    }
}
