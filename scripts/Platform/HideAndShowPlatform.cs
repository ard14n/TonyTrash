using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Die Platform wird immer wieder ein- und ausgeblendet.
 * Josephine Eckhoff 
 **/

public class HideAndShowPlatform : MonoBehaviour {
    // Use this for initialization
    IEnumerator PlatformHide() {
        Renderer renderer = gameObject.GetComponent<Renderer>();
        Collider collider = gameObject.GetComponent<Collider>();

        if(renderer.enabled == true)
        {
            yield return new WaitForSeconds(2.0f);
         
            renderer.enabled = false;
            collider.enabled = false;
        }

        else
        {
            yield return new WaitForSeconds(2.0f);
         
            renderer.enabled = true;
            collider.enabled = true;
        }
        }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(PlatformHide());
    }
   

}
