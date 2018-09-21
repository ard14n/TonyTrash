using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Animationen der Gullis werden random nacheinander abgespielt. 
 * Josephine Eckhoff
 */


public class Gulli : MonoBehaviour {

    private int number;
    private Animator firstJump;
    
    private bool doit = true;
    // Use this for initialization

    void Start () {
        firstJump = GetComponent<Animator>();
       

    }
	
	// Update is called once per frame
	void Update () {
       
        if (doit ==true) { 
        StartCoroutine(switchAnimation());
            doit = false;
        }
    }
 

    IEnumerator switchAnimation()
    {
        number = Random.Range(1, 4);
        switch (number)
        {
            case 1:
                firstJump.Play("Eins");
                yield return new WaitForSeconds(3.0f);
                gameObject.GetComponent<Animator>().Rebind();

                break;

            case 2:
                firstJump.Play("Zwei");
                yield return new WaitForSeconds(4.0f);
                gameObject.GetComponent<Animator>().Rebind();

                break;

            case 3:
                firstJump.Play("Drei");
                yield return new WaitForSeconds(4.0f);
                gameObject.GetComponent<Animator>().Rebind();
                break;



        }

        doit = true;





    }
   


    
}
