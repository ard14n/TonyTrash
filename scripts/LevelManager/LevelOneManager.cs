using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelOneManager : MonoBehaviour {

    private GameObject smasher;
    private GameObject gate;

    public bool bigTrashCollected;
    public bool enemiesKilled;
    public bool score;
    public bool minigameCompleted;

	// Use this for initialization
	void Start () {

        bigTrashCollected = false;
        enemiesKilled = false;
        score = false;
        minigameCompleted = false;
        smasher = GameObject.Find("Smasher");
        gate = GameObject.Find("Gate");
	}
	
	// Update is called once per frame
	void Update () {

        ActivateSmasher();
        OpenGate();

	}

    private void ActivateSmasher() {

        if (minigameCompleted && enemiesKilled && score && bigTrashCollected) {

            smasher.GetComponent<SmasherManager>().SetActivated();

        }

    }

    private void OpenGate() {

        if (minigameCompleted) {

            gate.GetComponent<GateManager>().OpenDoors();
        }

    }

    public void SetMiniGameCompleted() {

        this.minigameCompleted = true;

    }

    public void SetBigTrashCollected() {

        this.bigTrashCollected = true;

    }

    public void SetScoreCompleted() {

        this.score = true;

    }

    public void SetEnemiesKilled() {

        this.enemiesKilled = true;

    }

}
