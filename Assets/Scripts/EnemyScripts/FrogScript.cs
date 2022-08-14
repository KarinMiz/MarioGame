using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogScript : MonoBehaviour
{
    private Animator anim;
    private bool animationStarted;
    private bool animationFinished;
    private bool jumpLeft = true;
    private int jumpedTimes;

    private string coroutineName = "FrogJump";

    public LayerMask playerLayer;
    private GameObject player;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Start()
    {
        StartCoroutine(coroutineName);
        player = GameObject.FindGameObjectWithTag(MyTags.PLAYER_TAG);
    }
    private void Update()
    {
        if (Physics2D.OverlapCircle(transform.position, 0.5f, playerLayer))
        {
            player.GetComponent<PlayerDamege>().DealDamege();
        }
    }

    void LateUpdate()
    {
        if (animationFinished && animationStarted)
        {
            animationStarted = false;
            transform.parent.position = transform.position;
            transform.localPosition = Vector3.zero;
        }
    }

    IEnumerator FrogJump()
    {
        yield return new WaitForSeconds(Random.Range(1f, 4f));

        animationStarted = true;
        animationFinished = false;
        jumpedTimes++;
        if (jumpLeft)
        {
            anim.Play("FrogJumpLeft");
        }
        else
        {
            anim.Play("FrogJumpRight");
        }

        StartCoroutine(coroutineName);
    }

    void AnimationFinished()
    {
        animationFinished = true;
        if (jumpLeft)
        {
            anim.Play("FrogIdleLeft");
        }
        else
        {
            anim.Play("FrogIdleRight");
        }

        if (jumpedTimes == 3)
        {
            jumpedTimes = 0;
            Vector3 tempscale = transform.localScale;
            tempscale.x *= -1;
            transform.localScale = tempscale;

            jumpLeft = !jumpLeft;
        }

    }

    IEnumerator Dead(float timer)
    {
        yield return new WaitForSeconds(timer);
        gameObject.SetActive(false);
    }


    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == MyTags.BULLET_TAG)
        {
             StartCoroutine(Dead(0.4f));
             gameObject.SetActive(false);
        }
    }





}
