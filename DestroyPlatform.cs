using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Wenn der Spieler die Platform berührt, verschwindet die Plattform durch Änderung der Transparenz nach und nach.
 * Josephine Eckhoff
**/

public class DestroyPlatform : MonoBehaviour {

    public GameObject Player;
    public float duration = 2.0f;
    private bool fade = false;
    private float startTime = 0.0f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Player) {
            startTime = Time.time;
            Destroy(gameObject, duration);
            fade = true;
        }
    }

    private void Update()
    {
        if (fade)
        {
            Color col = gameObject.GetComponent<Renderer>().material.color;
            col.a = 1 - ((Time.time-startTime)/duration);
            gameObject.GetComponent<Renderer>().material.color = col;

        }
    }




}
