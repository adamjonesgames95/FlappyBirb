using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class Score : MonoBehaviour {

    Text CurrentScoreText;
    GlobalControl globalControl;

    // Use this for initialization
    void Start ()
    {
        CurrentScoreText = GameObject.FindGameObjectWithTag("ScoreText").GetComponent<Text>();
        globalControl = GameObject.FindObjectOfType<GlobalControl>();
        CurrentScoreText.text = "Score: " + globalControl.GetCurrentScore().ToString();
    }
	
	// Update is called once per frame
	void Update ()
    {

    }

    public void IncreaseScore()
    {
        globalControl.IncrementScore();
        CurrentScoreText.text = "Score: " + globalControl.GetCurrentScore().ToString();
    }

    

    public IEnumerator EndGame()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("Leaderboard");
    }
}
