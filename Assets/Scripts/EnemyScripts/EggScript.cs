using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggScript : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D target)
    {
        if(target.gameObject.tag == MyTags.PLAYER_TAG)
        {
            target.gameObject.GetComponent<PlayerDamege>().DealDamege();
        }
        gameObject.SetActive(false);
    }
}
