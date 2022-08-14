using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour
{
    public static GameController control;
    public int score;
    public int lifeScoreCount;
    private void Awake()
    {
        // If there's a control already, delete this
        //  If there's no control already, make this the control object
        if(control == null)
        {
            control = this;
            lifeScoreCount = 3;
            score = 0;
            DontDestroyOnLoad(gameObject);
        }
        else if (control != this)
        {
            Destroy(gameObject);
        }
    }
}
