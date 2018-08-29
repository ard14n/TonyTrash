using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushMeBox : MonoBehaviour {


    private GameObject pushableBox;
    private GameObject myCube;
    private GameObject player;
    private Rigidbody gameObjectsRigidBody;
    private float speed = 1f;

    private float x_coordinate;
    private float y_coordinate;
    private float z_coordinate;

	// Use this for initialization
	void Start () {

        pushableBox = GameObject.Find("PushMeBox");
        player = GameObject.Find("Player");

        x_coordinate = 30;
        y_coordinate = 4.1f;
        z_coordinate = 100;

        myCube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        myCube.transform.localScale = new Vector3(8f, 8f, 8f);
        myCube.transform.Translate(x_coordinate, y_coordinate, z_coordinate);

        myCube.transform.SetParent(pushableBox.transform);

        myCube.tag = "DoorOpenerBox";
        player.AddComponent<PushRigid>();

        gameObjectsRigidBody = myCube.AddComponent<Rigidbody>();        // Add the rigidbody.
        gameObjectsRigidBody.mass = 4f;                                 // Set the GO's mass to 5 via the Rigidbody.
        gameObjectsRigidBody.drag = 0;
        gameObjectsRigidBody.isKinematic = false;
        gameObjectsRigidBody.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY;


    }

    

    
}
