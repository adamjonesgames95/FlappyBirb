using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Birb : MonoBehaviour {

	float acceleration;
	float fallingSpeed;
    float angle;
    Score score;
    Pipe[] pipes;
    Parralax[] parralaxs;

    public AudioSource jumpSound;
    public AudioSource crashSound;

    // Use this for initialization
    void Start () 
	{
        score = FindObjectOfType<Score>();
        pipes = FindObjectsOfType<Pipe>();
        parralaxs = FindObjectsOfType<Parralax>();
		fallingSpeed = 0.0f;
		acceleration = -0.6f;
        angle = 0;

	}

    private void Update()
    {

        if (this.gameObject.transform.position.y < -6 | this.gameObject.transform.position.y > 6)
        {
            DeadBirb();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            fallingSpeed = 0.175f;
            angle = 20;
            jumpSound.Play();
        }

       
    }

    // Update is called once per frame
    void FixedUpdate () 
	{

       

		fallingSpeed += acceleration * Time.fixedDeltaTime;
        angle += acceleration * Time.fixedDeltaTime * 100;

        this.gameObject.transform.Translate(0.0f, fallingSpeed, 0.0f, Space.World);
        this.gameObject.transform.rotation = Quaternion.Euler(0.0f, 0.0f, angle);


    }

	void OnCollisionEnter2D(Collision2D coll)
	{
        DeadBirb();
    }

    void DeadBirb()
    {
        crashSound.Play();
        StartCoroutine(score.EndGame());
        this.enabled = false;
        for (int i = 0; i < pipes.Length; i++)
        {
            pipes[i].enabled = false;
        }

        for (int i = 0; i < parralaxs.Length; i++)
        {
            parralaxs[i].enabled = false;
        }
    }
}
