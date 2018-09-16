using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FassSpawner : MonoBehaviour {

    public GameObject barrellPrefab;
    private GameObject spawnedBarrell;
    private float spawnDelay = 5f;

    private float center = 385f;

    public bool stop = false;

    private Rigidbody barrellrigid;

	// Use this for initialization
	void Start () {


        TransformBarrel();
        ManipulateRigidbody();

        InvokeRepeating("SpawnBarrell", 2f, spawnDelay);
         
    }
	
	// Update is called once per frame
	void Update () {
		
	}


    public void SpawnBarrell() {

        Debug.Log("Ich spawne jetzt");
        
        Vector3 spawnPosition = new Vector3(-1170f, 430f, Random.Range(-9 + center, 9 + center));
        spawnedBarrell = Instantiate(barrellPrefab, spawnPosition, transform.rotation);
        

        if (stop) {
            CancelInvoke("SpawnBarrell");
        }
        
    }

    
    
    private void AddScriptToPrefab() {

        if (barrellPrefab != null)
            barrellPrefab.AddComponent<Barrells>();

    }

    private void ManipulateRigidbody() {

        barrellrigid = barrellPrefab.GetComponent<Rigidbody>();
        barrellrigid.constraints = RigidbodyConstraints.FreezePositionZ;

    }

    private void TransformBarrel() {

        //barrellPrefab = CreateBarrell();
        barrellPrefab.transform.rotation = Quaternion.Euler(90f, 0f, 0f);
        barrellPrefab.transform.localScale = new Vector3(20f, 20f, 20f);

    }




}
