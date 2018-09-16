using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPowerups : MonoBehaviour
{

    public GameObject[] powerups;
    private GameObject spawnedPowerups;
    int random;

    public float repeatTime;

    // Use this for initialization
    void Start()
    {
        InvokeRepeating("SpawnPowerup", 20f, repeatTime);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SpawnPowerup()
    {
        random = Random.Range(0, powerups.Length);
        Instantiate(powerups[random], transform.position, transform.rotation);
        

    }

}
