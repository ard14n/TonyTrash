using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Wenn der Spieler die Platform beruehrt, "zerbricht" die Plattform. Es werden kleine Wuerfel erzeugt, die herunterfallen. 
 * Josephine Eckhoff
 **/

public class PlatformBreaks : MonoBehaviour
{

    public GameObject Player;
    public Material newMaterialRef;
    public float cubeSize = 0.3f;
    public int cubesInRow = 5;
    public float scatter = 15.0f;
    public float duration = 3.0f;



    float cubesPivotDistance;
    Vector3 cubesPivot;
    // Use this for initialization
    void Start()
    {
        cubesPivotDistance = cubeSize * cubesInRow / 2;
        cubesPivot = new Vector3(cubesPivotDistance, cubesPivotDistance, cubesPivotDistance);
    }

    // Update is called once per frame
    void Update()
    {


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

        for (int x = 0; x < cubesInRow; x++)
        {
            for (int y = 0; y < 2; y++)
            {
                for (int z = 0; z < cubesInRow; z++)
                {
                    BrokenPieces(x, y, z);
                }
            }

        }
        gameObject.SetActive(false);
    }


    void BrokenPieces(int x, int y, int z)
    {
        //kleine Wuerfel erzeugen

        GameObject smallCube;
        smallCube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        smallCube.name = "cubePiece";

        smallCube.transform.position = transform.position + new Vector3(cubeSize * x, cubeSize * y, cubeSize * z) - cubesPivot;
        smallCube.transform.localScale = new Vector3(cubeSize, cubeSize, cubeSize);
        smallCube.GetComponent<Renderer>().material = newMaterialRef;

        smallCube.AddComponent<Rigidbody>();
        smallCube.GetComponent<Rigidbody>().mass = 0.01f;
        smallCube.GetComponent<Rigidbody>().AddForce(Random.Range(-scatter, scatter), 0, Random.Range(-scatter, scatter));
        smallCube.GetComponent<Rigidbody>().AddTorque(Random.Range(-scatter, scatter) * 80, Random.Range(-scatter, scatter) * 80, Random.Range(-scatter, scatter) * 80);
        Destroy(smallCube, duration);
    }
}
