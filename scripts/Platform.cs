using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Plattform wird erzeugt
 * Josephine Eckhoff
 **/

public class Platform : MonoBehaviour {

    public GameObject platform;
    public Material newMaterialRef;
    float x = -212.26f;
    float y = 8.0f;
    float z = 85.68f;
    // Use this for initialization
    void Start()
    {
        platform = GameObject.CreatePrimitive(PrimitiveType.Cube);
        platform.transform.localScale = new Vector3(7.0f, 0.5f, 7.0f);
        platform.transform.Translate(x, y, z);
        platform.GetComponent<Renderer>().material = newMaterialRef;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
