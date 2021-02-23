using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Difficulty : MonoBehaviour {

    public Dropdown myDropdown;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

        switch (myDropdown.value)
        {
            case 0:
                GlobalControl.Difficulty = 1;
                break;
            case 1:
                GlobalControl.Difficulty = 2;
                break;
            case 2:
                GlobalControl.Difficulty = 3;
                break;
        }
	}
}
