using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTruck : MonoBehaviour {

    public GameObject trashPrefab;
    private GameObject spawnedTrash;

    public Vector3 center;
    public Vector3 size;

    public float repeatTime;

	// Use this for initialization
	void Start () {
        InvokeRepeating("SpawnTrash", 10f, repeatTime);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void SpawnTrash()
    {
        Vector3 pos = center + new Vector3(Random.Range(-size.x / 2, size.x / 2), Random.Range(-size.y / 2, size.y / 2), Random.Range(-size.z / 2, size.z / 2));
        spawnedTrash = Instantiate(trashPrefab, transform.position + pos, transform.rotation);
        spawnedTrash.AddComponent<MagnetBehavior>();
        spawnedTrash.AddComponent<CharacterController>();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawCube(transform.position, size);
    }
}
