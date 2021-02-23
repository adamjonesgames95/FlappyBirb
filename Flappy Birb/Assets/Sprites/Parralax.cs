using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parralax : MonoBehaviour
{
    private float length, startPos, count, speed;
    public float parralaxEffect;
    GameObject birb;



    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
        speed = 2.0f;
        birb = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        count += 0.1f;


        float temp = (count * (1 - parralaxEffect));
        float dist = (count * parralaxEffect);

        this.gameObject.transform.Translate(-speed * Time.deltaTime * parralaxEffect, 0.0f, 0.0f);

        if (this.gameObject.transform.position.x < -34.02f)
        {
            this.gameObject.transform.position = new Vector2(34.02f, 0.0f);
        }

    }
}
