using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour {

	float speed;
    GameObject birb;
    Score score;
    bool scoreIncremented = false;
    Transform childPipe;
    float pipeGap;

	// Use this for initialization
	void Start () 
	{
		speed = 3.0f;
        birb = GameObject.FindGameObjectWithTag("Player");
        InitPosition ();
        score = GameObject.FindGameObjectWithTag("ScoreText").GetComponent<Score>();


        if (GlobalControl.Difficulty == 1)
            pipeGap = 1.75f;
        else if (GlobalControl.Difficulty == 3)
            pipeGap = 1.65f;
        else
            pipeGap = 1.7f;

        childPipe = gameObject.transform.GetChild(0);
        childPipe.transform.localPosition = new Vector3(0, pipeGap, 0);
	}

    public bool behindBirb
    {
        get { return _behindBirb; }
        set
        {
            _behindBirb = value;
            if (_behindBirb == true & scoreIncremented == false)
            {
                score.IncreaseScore();
                scoreIncremented = true;
            }
        }
    }

    private bool _behindBirb;

    // Update is called once per frame
    void Update () 
	{
        if (birb == null)
        {
            TurnOff();
        }

		if (this.gameObject.transform.position.x <= -14) 
		{
			this.gameObject.transform.position = new Vector2(14.0f, Random.Range(-4.0f,-8.0f));
            behindBirb = false;
            scoreIncremented = false;
		}
			
		this.gameObject.transform.Translate (-speed * Time.deltaTime, 0.0f, 0.0f);

        if (this.gameObject.transform.position.x < birb.transform.position.x)
        {
            behindBirb = true;
        }
	}

	void InitPosition()
	{
        this.gameObject.transform.position = new Vector2(this.gameObject.transform.position.x, Random.Range(-3.0f,-8.0f));
	}

    void TurnOff()
    {
        this.enabled = false;
    }
}
