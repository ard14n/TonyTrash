using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Plattform bewegt sich nach oben und unten, waehrenddessen abwechselnd nach rechts und links. 
 * Josephine Eckhoff
 */

public class ObjectMove : MonoBehaviour {

    public bool floatup = true;
    private int zAchseUp = 1;
    private int zAchseDown = 1;

    IEnumerator UpDown()
    {
        if (floatup == true)
        {
            if(zAchseUp == 1) {
            transform.position += new Vector3(0.0f, 3.0f * Time.deltaTime, 3.0f * Time.deltaTime);  
            yield return new WaitForSeconds(2.0f);
            floatup = false;
            zAchseUp = 2;
            }
            else if (zAchseUp ==2)
            {
                transform.position += new Vector3(0.0f, 3.0f * Time.deltaTime, -3.0f * Time.deltaTime);
                yield return new WaitForSeconds(2.0f);
                floatup = false;
                zAchseUp = 1;
            }

        }
        else if (floatup == false)
        {
            if (zAchseDown == 1)
            {
                transform.position += new Vector3(0.0f, -3.0f * Time.deltaTime, -3.0f * Time.deltaTime);
                yield return new WaitForSeconds(2.0f);
                floatup = true;
                zAchseDown = 2;
            }
            else if (zAchseDown ==2)
            {
                transform.position += new Vector3(0.0f, -3.0f * Time.deltaTime, 3.0f * Time.deltaTime);
                yield return new WaitForSeconds(2.0f);
                floatup = true;
                zAchseDown = 1;
            }
        }
    }

  
	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        StartCoroutine(UpDown());
    }
}
