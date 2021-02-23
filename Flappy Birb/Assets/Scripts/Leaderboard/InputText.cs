using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputText : MonoBehaviour {

    HighScores highScores;
    Text playerName;

	// Use this for initialization
	void Start ()
    {
        highScores = FindObjectOfType<HighScores>();
        playerName = FindObjectOfType<Text>();

    }

    // Update is called once per frame
    void Update ()
    {
        //if (Input.GetKeyDown(KeyCode.Return))
        //{
        //    print("here");
        //    highScores.PlayerName = playerName.text;
        //    highScores.DisplayHighScores();
        //}
    }

    //public void Text_Changed(string newText)
    //{
    //    
    //}
}
