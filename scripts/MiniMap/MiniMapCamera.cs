using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapCamera : MonoBehaviour {

    private GameObject player;
    private Transform playerTransform;
    public float cameraHeight = 200f;

    void Start() {

        player = GameObject.Find("Player");
        playerTransform = player.transform;

        this.gameObject.GetComponent<Camera>().fieldOfView = 90f;

    }


	void LateUpdate() {

        transform.position = new Vector3(playerTransform.position.x, playerTransform.position.y+cameraHeight, playerTransform.position.z);
        
    }
}
