using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bouns : MonoBehaviour
{
    public Transform bottomCollsion;
    private Animator anim;
    public LayerMask playerLayer;
    private Vector3 moveDirction = Vector3.up;
    private Vector3 originPosition;
    private Vector3 animPosition;
    private bool startAnim;
    private bool canAnim =true;

    /*private Text goldScore;
    private int goldCount = 0;*/
    //private AudioSource audioManager;
    
    


    private void Awake()
    {
        anim = GetComponent<Animator>();
        
    }
    void Start()
    {
        originPosition = transform.position;
        animPosition = transform.position;
        animPosition.y += 0.15f;
        //audioManager = GetComponent<AudioSource>();
        //goldScore = GameObject.Find("GoldText").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckForCollision();
        AnimateUpDown();
    }

    void CheckForCollision()
    {
        if (canAnim)
        {
            RaycastHit2D hit = Physics2D.Raycast(bottomCollsion.position, Vector2.down, 0.1f, playerLayer);
            if (hit)
            {
                if (hit.collider.gameObject.tag == MyTags.PLAYER_TAG)
                {
                    //audioManager.Play();
                    anim.Play("IdleGold");
                    /*goldCount++;
                    goldScore.text = "x" + goldCount;*/
                    startAnim = true;
                    canAnim = false;
                }
            }
        }
    }
    void AnimateUpDown()
    {
        if (startAnim)
        {
            transform.Translate(moveDirction * Time.smoothDeltaTime);
            if(transform.position.y >= animPosition.y)
            {
                moveDirction = Vector3.down;
            }
            else if( transform.position.y<= originPosition.y)
            {
                startAnim = false;
            }
        }
    }
}
