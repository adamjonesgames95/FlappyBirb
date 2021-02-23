using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
using System;
using System.Text.RegularExpressions;
using System.Linq;

public class HighScores : MonoBehaviour {

    List<int> scoreList = new List<int>();
    List<string> nameList = new List<string>();
    GlobalControl globalControl;
    Text displayScores;
    Text displayNames;
    List<GameObject> templistscores = new List<GameObject>();
    List<GameObject> templistnames = new List<GameObject>();
    public Text InputFieldText;
    public InputField inputField;
    public string PlayerName = "";
    bool displayed = false;

    // Use this for initialization
    void Start ()
    {
        globalControl = GameObject.FindObjectOfType<GlobalControl>();
        ReadString();
        templistscores.AddRange(GameObject.FindGameObjectsWithTag("HighScore"));
        templistnames.AddRange(GameObject.FindGameObjectsWithTag("HighScoreName"));

        templistnames.Sort(delegate (GameObject x, GameObject y)
        {
            return string.Compare(x.name, y.name);
        });
        templistscores.Sort(delegate (GameObject x, GameObject y)
        {
            return string.Compare(x.name, y.name);
        });
 

    }
	
	// Update is called once per frame
	void Update ()
    {
        if (!displayed)
        {
            if (globalControl.GetCurrentScore() <= scoreList[4])
            {
                DisplayHighScores();
                inputField.transform.Translate(100, 100, 0);
                displayed = true;
            }
            else if (Input.GetKeyDown(KeyCode.Return))
            {
                PlayerName = InputFieldText.text;
                inputField.transform.Translate(100, 100, 0);
                DisplayHighScores();
                WriteString();
                displayed = true;
            }  
        }

        if (displayed)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene("Menu");
            }
        }
    }

    void WriteString()
    {
        string path = Application.dataPath + "/Resources/HighScores.txt";

        StreamWriter writer = new StreamWriter(path, false);

        for (int i = 0; i < 5; i++)
        {
            writer.WriteLine("{0} {1}", nameList[i], scoreList[i]);
        }
        
        writer.Close();
    }

    void ReadString()
    {
        string path = Application.dataPath + "/Resources/HighScores.txt";

        FileStream fs = new FileStream(path, FileMode.Open);
        string content = "";
        using (StreamReader read = new StreamReader(fs, true))
        {
            content = read.ReadToEnd();
        }

        string[] datalist = Regex.Split(content, Environment.NewLine);

        for (int i = 0; i < 5; i++)
        {
            string[] temp = datalist[i].Split(' ');

            nameList.Add(temp[0]);
            scoreList.Add(Convert.ToInt32(temp[1]));
        }

    }

    public void DisplayHighScores()
    {

        bool end = false;
        int i = 4;

        scoreList.Add(globalControl.GetCurrentScore());
        nameList.Add(PlayerName);

        do
        {
            if (globalControl.GetCurrentScore() > scoreList[i])
            {
                int temp = scoreList[i];
                scoreList[i] = scoreList[i + 1];
                scoreList[i + 1] = temp;

                string temp2 = nameList[i];
                nameList[i] = nameList[i + 1];
                nameList[i + 1] = temp2;

                i--;

                if (i < 0)
                {
                    end = true;
                }
            }
            else
            {
                end = true;
            }
        }
        while (end == false);

        scoreList.RemoveAt(5);


        displayNames = templistnames[0].GetComponent<Text>();
        displayScores = templistscores[0].GetComponent<Text>();

        for (int k = 0; k < 5; k++)
        {
            displayNames = templistnames[k].GetComponent<Text>();
            displayScores = templistscores[k].GetComponent<Text>();

            displayNames.text = nameList[k];
            displayScores.text = scoreList[k].ToString();

        }
    }
}
