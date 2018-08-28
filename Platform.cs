using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Plattform wird erzeugt
 * Josephine Eckhoff
 **/

public class Platform : MonoBehaviour {

    public GameObject platform;
    int x = -211;
    int y = 10;
    int z = 73;
    // Use this for initialization
    void Start()
    {
        platform = GameObject.CreatePrimitive(PrimitiveType.Cube);
        platform.transform.localScale = new Vector3(7.0f, 0.5f, 7.0f);
        platform.transform.Translate(x, y, z);
        platform.GetComponent<Renderer>().material.color = new Color(0.0f, 1.0f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
