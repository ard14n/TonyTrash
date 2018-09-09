﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildMinigamePlatform : MonoBehaviour {

    private GameObject minigame;
    private GameObject miniGamePivotPoint;
    private GameObject miniGameBase;
    private GameObject wallEast;
    private GameObject wallSouth;
    private GameObject wallWest;
    private GameObject wallNorth;
    private GameObject ball;

    private Rigidbody ballbody;

    private Vector3 baseSpawnPosition;
    private Vector3 basePosition;

    private Vector3 ballSpawn;
    private Vector3 ballDestination;

    private Vector3 wallSouthSpawn;
    private Vector3 wallSouthDestination;

    private Vector3 wallNorthSpawn;
    private Vector3 wallNorthDestination;

    private Vector3 wallEastSpawn;
    private Vector3 wallEastDestination;

    private Vector3 wallWestSpawn;
    private Vector3 wallWestDestination;

    public Material baseMaterial;
    public Material sphereMaterial;

    public bool startBuilding = false;
    
    // Use this for initialization
    void Start() {

        minigame = GameObject.Find("MiniGame");
        GenerateSpawnPoints();
        GeneratePositionPoints();
        BuildPivotPoint();
        BuildBase();
        BuildWalls();
        BuildSphere();
        BuildFinishGameTrigger();

    }

    // Update is called once per frame
    void Update() {

        if (startBuilding) {

            MoveToDestination();

        }

    }

    

    private void BuildBase() {
        
        miniGameBase = GameObject.CreatePrimitive(PrimitiveType.Cube);

        miniGameBase.name = "DynamicBase";
        miniGameBase.transform.SetParent(miniGamePivotPoint.transform);
        ScaleGameObject(miniGameBase, 1f, 1f, 1f);
        miniGameBase.transform.localPosition = baseSpawnPosition;
        
        miniGameBase.AddComponent<BoxCollider>();

        Rigidbody basebody = miniGameBase.AddComponent<Rigidbody>();
        basebody.mass = 100;
        basebody.drag = 0;
        basebody.angularDrag = 0;
        basebody.isKinematic = true;
        basebody.useGravity = false;

        try {

            baseMaterial = Resources.Load("Orange", typeof(Material)) as Material;
            miniGameBase.GetComponent<Renderer>().material = baseMaterial;

        } catch {

        }
        
    }

    private void BuildWalls() {
        
        wallEast = GameObject.CreatePrimitive(PrimitiveType.Cube);
        wallEast.name = "WallEast";
        wallEast.transform.SetParent(miniGameBase.transform);
        wallEast.transform.localPosition = wallEastSpawn;
        ScaleGameObject(wallEast, 1f, 0.05f, 1f);
        RotateGameObject(wallEast, 90f, 0f, 0f);

        wallSouth = GameObject.CreatePrimitive(PrimitiveType.Cube);
        wallSouth.name = "WallSouth";
        wallSouth.transform.SetParent(miniGameBase.transform);
        wallSouth.transform.localPosition = wallSouthSpawn;
        ScaleGameObject(wallSouth, 1f, 0.05f, 1f);
        RotateGameObject(wallSouth, 90f, 90f, 0f);

        wallNorth = GameObject.CreatePrimitive(PrimitiveType.Cube);
        wallNorth.name = "WallNorth";
        wallNorth.transform.SetParent(miniGameBase.transform);
        wallNorth.transform.localPosition = wallNorthSpawn;
        ScaleGameObject(wallNorth, 1f, 0.05f, 1f);
        RotateGameObject(wallNorth, 90f, 90f, 0f);

        wallWest = GameObject.CreatePrimitive(PrimitiveType.Cube);
        wallWest.name = "WallWest";
        wallWest.transform.SetParent(miniGameBase.transform);
        wallWest.transform.localPosition = wallWestSpawn;
        ScaleGameObject(wallWest, 1f, 0.05f, 1f);
        RotateGameObject(wallWest, 90f, 0f, 0f);

        GameObject cube5 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube5.name = "Cube5";
        cube5.transform.SetParent(miniGameBase.transform);
        cube5.transform.localPosition = new Vector3(-0.154f, 0.95f, -0.213f);
        ScaleGameObject(cube5, 0.5f, 0.05f, 1f);
        RotateGameObject(cube5, 90f, 90f, 0f);

        GameObject cube6 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube6.name = "Cube6";
        cube6.transform.SetParent(miniGameBase.transform);
        cube6.transform.localPosition = new Vector3(0.051f, 0.95f, 0.233f);
        ScaleGameObject(cube6, 0.5f, 0.05f, 1);
        RotateGameObject(cube6, 90f, 90f, 0f);

        GameObject cube7 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube7.name = "Cube7";
        cube7.transform.SetParent(miniGameBase.transform);
        cube7.transform.localPosition = new Vector3(0.371f, 0.95f, 0.017f);
        ScaleGameObject(cube7, 0.25f, 0.05f, 1);
        RotateGameObject(cube7, 90f, 90f, 90f);

    }

    private void BuildSphere() {
        
        ball = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        ball.name = "Kugel";
        ball.transform.SetParent(minigame.transform);
        ball.transform.localPosition = ballSpawn;
        ScaleGameObject(ball, 10f, 10f, 10f);

        ball.AddComponent<SphereCollider>();

        ballbody = ball.AddComponent<Rigidbody>();
        ballbody.mass = 7;
        ballbody.useGravity = true;
        ballbody.drag = 0;

        try {

            sphereMaterial = Resources.Load("Blue", typeof(Material)) as Material;
            ball.GetComponent<Renderer>().material = sphereMaterial;

        } catch (System.Exception) {


        }


    }

    private void BuildPivotPoint() {

        Vector3 pivotDestination = new Vector3(181.3248f, 160.917f, 16.41764f);
        miniGamePivotPoint = new GameObject("DynamicPivotPoint");
       
        miniGamePivotPoint.transform.SetParent(minigame.transform);
        ScaleGameObject(miniGamePivotPoint, 100f, 10f, 100f);
        miniGamePivotPoint.transform.localPosition = pivotDestination;

        miniGamePivotPoint.AddComponent<MiniGameController>();

    }

    private void BuildFinishGameTrigger() {

        GameObject finishArea = GameObject.CreatePrimitive(PrimitiveType.Cube);
        finishArea.transform.SetParent(miniGameBase.transform);
        finishArea.name = "KugelZiel";
        finishArea.transform.localPosition = new Vector3(0.2468f, 0.618999f, 0.242f);
        ScaleGameObject(finishArea, 0.4f, 0.2f, 0.4f);

        BoxCollider collider = finishArea.AddComponent<BoxCollider>();
        collider.isTrigger = true;

        finishArea.AddComponent<FinishGameTrigger>();
        finishArea.GetComponent<MeshRenderer>().enabled = false;

    }

    private void GenerateSpawnPoints() {

        wallEastSpawn = new Vector3(300, 300, -300);
        wallWestSpawn = new Vector3(300, 300, 300);
        wallNorthSpawn = new Vector3(300, 300, 0);
        wallSouthSpawn = new Vector3(-300, 300, 0);

        ballSpawn = new Vector3(1000, 1000, 1000);

        baseSpawnPosition = new Vector3(500, 500, 500);

    }

    private void GeneratePositionPoints() {

        basePosition = new Vector3(0f, 0.0470001f, 0f);
        ballDestination = new Vector3(152.4f, 191.3f, -16f);
        wallEastDestination = new Vector3(0.001826477f, 0.9599999f, -0.477f);
        wallNorthDestination = new Vector3(0.4738264f, 0.9299999f, 0f);
        wallSouthDestination = new Vector3(-0.4761735f, 0.95f, -0.001000004f);
        wallWestDestination = new Vector3(0.001826477f, 0.9599999f, 0.472f);

    }
     
    private bool CheckBaseBuild(){

        if (miniGameBase.transform.localPosition == basePosition) {

            return true;
        }

        return false;

    }

    private bool CheckSphereBuild() {

        if (ball.transform.localPosition == ballDestination) {

            return true;

        }

        return false;

    }

    private void RotateGameObject(GameObject g, float x, float y, float z){

        g.transform.localRotation = Quaternion.Euler(x, y, z);

    }

    private void ScaleGameObject(GameObject g, float x, float y, float z) {

        g.transform.localScale = new Vector3(x, y, z);

    }

    private void MoveToDestination(){

        miniGameBase.transform.localPosition = Vector3.Lerp(miniGameBase.transform.localPosition, basePosition, Time.deltaTime*100f);
        ball.transform.localPosition = Vector3.Lerp(ball.transform.localPosition, ballDestination, Time.deltaTime);
        wallEast.transform.localPosition = Vector3.Lerp(wallEast.transform.localPosition, wallEastDestination, Time.deltaTime);
        wallNorth.transform.localPosition = Vector3.Lerp(wallNorth.transform.localPosition, wallNorthDestination, Time.deltaTime);
        wallSouth.transform.localPosition = Vector3.Lerp(wallSouth.transform.localPosition, wallSouthDestination, Time.deltaTime);
        wallWest.transform.localPosition = Vector3.Lerp(wallWest.transform.localPosition, wallWestDestination, Time.deltaTime);

    }

    
    
    public void StartBuilding() {

       
        this.startBuilding = true;

    }
}
