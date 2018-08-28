using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Wenn der Spieler die Platform beruehrt, "zerbricht" die Plattform. Es werden kleine Wuerfel erzeugt, die herunterfallen. 
 * Josephine Eckhoff
 **/

public class PlatformBreaks : MonoBehaviour {

    public GameObject Player;
    public float cubeSize = 0.2f;
    public int cubesInRow = 2;
    public float radius = 5.0f;
    public float power = 10.0f;

    float cubesPivotDistance;
    Vector3 cubesPivot;
    // Use this for initialization
    void Start () {
        cubesPivotDistance = cubeSize * cubesInRow / 2;
        cubesPivot = new Vector3(cubesPivotDistance, cubesPivotDistance, cubesPivotDistance);
	}
	
	// Update is called once per frame
	void Update () {
   

    }

    private void OnTriggerEnter(Collider other)
    {
        //BreakPlatform wird aufgerufen, wenn Player die Platform berührt
        if (other.gameObject == Player)
        {
            BreakPlatform();
        }
         
    }
    public void BreakPlatform()
    {
        gameObject.SetActive(false);
        for (int x = 0; x < cubesInRow; x++)
        {
            for (int y = 0; y < 2; y++)
            {
                for (int z = 0; z < cubesInRow; z++)
                {
                    brokenPieces(x, y, z);
                }
            }
        }
        //Position für Explosion
        Vector3 explosionPos = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if (rb != null)
                rb.AddExplosionForce(power, explosionPos, radius, 3.0f);
        }
    }
    void brokenPieces(int x, int y, int z)
    {
        //kleine Wuerfel erzeugen
       GameObject smallCube;
        smallCube = GameObject.CreatePrimitive(PrimitiveType.Cube);

        smallCube.transform.position = transform.position + new Vector3(cubeSize * x, cubeSize * y, cubeSize * z) - cubesPivot;
        smallCube.transform.localScale = new Vector3(cubeSize, cubeSize, cubeSize);
        smallCube.GetComponent<Renderer>().material.color = new Color(0.0f, 1.0f, 0.0f);

        smallCube.AddComponent<Rigidbody>();
        smallCube.AddComponent<Rigidbody>().mass = cubeSize;

    }
}
