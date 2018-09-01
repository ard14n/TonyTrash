using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildMinigamePlatform : MonoBehaviour {

    private GameObject minigame;

    // Use this for initialization
    void Start() {

        minigame = GameObject.Find("MiniGame");

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void BuildBase() {

        Vector3 cubeSpawn = new Vector3(200, 200, 200);
        Vector3 cubeDestination = new Vector3(181.3248f, 165.617f, 16.41764f);

        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.name = "MiniGameBase";
        cube.transform.localScale = new Vector3(100f, 10f, 100f);
        cube.transform.position = cubeSpawn;

        cube.transform.SetParent(minigame.transform);
        
    }

    private void BuildWalls() {



    }

    private void BuildSphere() {

    }

    private void BuildPivotPoint() {

        
        Vector3 pivotDestination = new Vector3(181.3248f, 160.917f, 16.41764f);

        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.transform.localScale = new Vector3(100f, 10f, 100f);
        cube.transform.position = pivotDestination;

    }
}
