using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerDamege : MonoBehaviour
{
    private Text lifeText;
   // private int lifeScoreCount;
    private bool canDamage;

    private void Awake()
    {
        lifeText = GameObject.Find("LifeText").GetComponent<Text>();
        lifeText.text = "x" + 3;
        canDamage = true;
    }
    private void Start()
    {
        lifeText = GameObject.Find("LifeText").GetComponent<Text>();
        lifeText.text = "x" + GameController.control.lifeScoreCount;
        Time.timeScale = 1f;
    }
    public void DealDamege() {
        if (canDamage)
        {
            GameController.control.lifeScoreCount--;
            if (GameController.control.lifeScoreCount >= 0)
            {
                lifeText.text = "x" + GameController.control.lifeScoreCount;
            }
            if (GameController.control.lifeScoreCount == 0)
            {
                Time.timeScale = 0f;
                StartCoroutine(RestartGame());
            }
            canDamage = false;
            StartCoroutine(waitForDamege());
        }
        
    }

   

    IEnumerator waitForDamege()
    {
        yield return new WaitForSeconds(2f);
        canDamage = true;
    }

    IEnumerator RestartGame()
    {
        yield return new WaitForSecondsRealtime(2f);
        GameController.control.lifeScoreCount = 3;
        GameController.control.score = 0;
        SceneManager.LoadScene("TryAgainMenu");
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if(target.tag == MyTags.WATER_TAG)
        {
            Time.timeScale = 0f;
            StartCoroutine(RestartGame());
        }
    }
}
