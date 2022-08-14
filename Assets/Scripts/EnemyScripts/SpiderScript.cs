using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderScript : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D myBody;
    private Vector3 moveDircection = Vector3.down;

    private string coroutine_Name = "ChangeMovement";

    private void Awake()
    {
        anim = GetComponent<Animator>();
        myBody = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        StartCoroutine(coroutine_Name);
    }


    void Update()
    {
        MoveSpider();
    }

    void MoveSpider()
    {
        transform.Translate(moveDircection * Time.smoothDeltaTime);

    }

    IEnumerator ChangeMovement()
    {
        yield return new WaitForSeconds(Random.Range(2f, 5f));
        if (moveDircection == Vector3.down)
        {
            moveDircection = Vector3.up;
        }
        else
        {
            moveDircection = Vector3.down;
        }
            
        StartCoroutine(coroutine_Name);
    }

    IEnumerator SpiderDead()
    {
        yield return new WaitForSeconds(3f);
        gameObject.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if(target.tag == MyTags.BULLET_TAG)
        {
            anim.Play("SpiderDead");
            myBody.bodyType = RigidbodyType2D.Dynamic;
            StartCoroutine(SpiderDead());
            StopCoroutine(coroutine_Name);
        }

        if(target.tag == MyTags.PLAYER_TAG)
        {
            target.GetComponent<PlayerDamege>().DealDamege();
        }
    }
}
