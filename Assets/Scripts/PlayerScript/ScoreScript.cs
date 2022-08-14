using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreScript : MonoBehaviour
{
    private Text coinScore;
    private AudioSource audioManager;

    private void Awake()
    {
        audioManager = GetComponent<AudioSource>();

    }
    void Start()
    {
        coinScore = GameObject.Find("CoinText").GetComponent<Text>();
        coinScore.text = "x" + GameController.control.score;
    }

    
    void Update()
    {
        
    }
    IEnumerator NextLeve()
    {
        yield return new WaitForSecondsRealtime(2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    private void OnTriggerEnter2D(Collider2D target)
    {
        if(target.tag == MyTags.COIN_TAG)
        {
            target.gameObject.SetActive(false);
            GameController.control.score++;
            coinScore.text = "x" + GameController.control.score;
            audioManager.Play();
        }

        if(target.tag == MyTags.Finish_TAG)
        {
            StartCoroutine(NextLeve());
        }
        if (target.tag == MyTags.Castel_TAG)
        {
            GameController.control.lifeScoreCount = 3;
            GameController.control.score = 0;
            StartCoroutine(NextLeve());
        }
    }
    
}
