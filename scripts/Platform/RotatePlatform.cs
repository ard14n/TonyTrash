using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlatform : MonoBehaviour {

    /* Plattform neigt sich um die z-Achse abwechselnd nach vorne und hinten.
     * Josephine Eckhoff
     */

    public GameObject platform;
    private float speed = 0.2f;
    public bool rotate = true;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(RotatePlat());
    }

    IEnumerator RotatePlat()
    {
        if (rotate == true)
        {
            platform.transform.Rotate(0, 0, speed);
            yield return new WaitForSeconds(3.0f);
            platform.transform.Rotate(0, 0, -speed);
            yield return new WaitForSeconds(0.2f);
            rotate = false;
        }

        else if (rotate == false)
        {

            platform.transform.Rotate(0, 0, -speed);
            yield return new WaitForSeconds(3.0f);
            platform.transform.Rotate(0, 0, speed);
            yield return new WaitForSeconds(0.2f);
            rotate = true;
        }
            
        
        }

    
}

