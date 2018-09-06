using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildMinigamePlatform : MonoBehaviour {

    private GameObject minigame;
    private GameObject miniGamePivotPoint;
    private GameObject miniGameCube;

    // Use this for initialization
    void Start() {

        minigame = GameObject.Find("MiniGame");
        BuildPivotPoint();
        BuildBase();
        BuildWalls();
        BuildSphere();

    }

    // Update is called once per frame
    void Update()
    {

    }

    

    private void BuildBase() {

        Vector3 cubeSpawn = new Vector3(200, 200, 200);
        Vector3 cubeDestination = new Vector3(0, 0.0470001f, 0);

        miniGameCube = GameObject.CreatePrimitive(PrimitiveType.Cube);

        miniGameCube.name = "DynamicBase";
        miniGameCube.transform.SetParent(miniGamePivotPoint.transform);
        miniGameCube.transform.localScale = new Vector3(1, 1, 1);
        miniGameCube.transform.localPosition = cubeDestination;

    }

    private void BuildWalls() {

        GameObject wallEast = GameObject.CreatePrimitive(PrimitiveType.Cube);
        wallEast.name = "WallEast";
        wallEast.transform.SetParent(miniGameCube.transform);
        wallEast.transform.localPosition = new Vector3(0.001826477f, 0.9599999f, -0.477f);
        wallEast.transform.localScale = new Vector3(1, 0.05f, 1);
        wallEast.transform.localRotation = Quaternion.Euler(90f, 0, 0);
        
        GameObject wallSouth = GameObject.CreatePrimitive(PrimitiveType.Cube);
        wallSouth.name = "WallSouth";
        wallSouth.transform.SetParent(miniGameCube.transform);
        wallSouth.transform.localPosition = new Vector3(-0.4761735f, 0.95f, -0.001000004f);
        wallSouth.transform.localScale = new Vector3(1, 0.05f, 1);
        wallSouth.transform.localRotation = Quaternion.Euler(90f, 90f, 0);

        GameObject wallNorth = GameObject.CreatePrimitive(PrimitiveType.Cube);
        wallNorth.name = "WallNorth";
        wallNorth.transform.SetParent(miniGameCube.transform);
        wallNorth.transform.localPosition = new Vector3(0.4738264f, 0.9299999f, 0);
        wallNorth.transform.localScale = new Vector3(1, 0.05f, 1);
        wallNorth.transform.localRotation = Quaternion.Euler(90f, 90f, 0);

        GameObject wallWest = GameObject.CreatePrimitive(PrimitiveType.Cube);
        wallWest.name = "WallWest";
        wallWest.transform.SetParent(miniGameCube.transform);
        wallWest.transform.localPosition = new Vector3(0.001826477f, 0.9599999f, 0.472f);
        wallWest.transform.localScale = new Vector3(1, 0.05f, 1);
        wallWest.transform.localRotation = Quaternion.Euler(90f, 0, 0);

        GameObject cube5 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube5.name = "Cube5";
        cube5.transform.SetParent(miniGameCube.transform);
        cube5.transform.localPosition = new Vector3(-0.154f, 0.95f, -0.213f);
        cube5.transform.localScale = new Vector3(0.5f, 0.05f, 1);
        cube5.transform.localRotation = Quaternion.Euler(90f, 90f, 0);

        GameObject cube6 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube6.name = "Cube6";
        cube6.transform.SetParent(miniGameCube.transform);
        cube6.transform.localPosition = new Vector3(0.051f, 0.95f, 0.233f);
        cube6.transform.localScale = new Vector3(0.5f, 0.05f, 1);
        cube6.transform.localRotation = Quaternion.Euler(90f, 90f, 0);

        GameObject cube7 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube7.name = "Cube7";
        cube7.transform.SetParent(miniGameCube.transform);
        cube7.transform.localPosition = new Vector3(0.371f, 0.95f, 0.017f);
        cube7.transform.localScale = new Vector3(0.25f, 0.05f, 1);
        cube7.transform.localRotation = Quaternion.Euler(90f, 90f, 90f);

    }

    private void BuildSphere() {

        GameObject ball = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        ball.name = "Ball";
        ball.transform.SetParent(minigame.transform);
        ball.transform.localPosition = new Vector3(152.4384f, 171.387f, -15.95023f);
        ball.transform.localScale = new Vector3(10,10,10);

    }

    private void BuildPivotPoint() {

        Vector3 pivotDestination = new Vector3(181.3248f, 160.917f, 16.41764f);
        miniGamePivotPoint = new GameObject();
        miniGamePivotPoint.name = "DynamicPivotPoint";
        
        miniGamePivotPoint.transform.SetParent(minigame.transform);
        miniGamePivotPoint.transform.localScale = new Vector3(100f, 10f, 100f);
        miniGamePivotPoint.transform.localPosition = pivotDestination;

    }
}
