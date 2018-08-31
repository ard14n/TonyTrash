using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmasherManager : MonoBehaviour {

    private GameObject smasherOne;
    private GameObject smasherTwo;

	// Use this for initialization
	void Start () {

        smasherOne = GameObject.Find("SmasherOne");
        smasherTwo = GameObject.Find("SmasherTwo");

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetActivated() {

        smasherOne.GetComponent<SmasherOne>().SetActivated();
        smasherTwo.GetComponent<SmasherTwo>().SetActivated();

    }
}
