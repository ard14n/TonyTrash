using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigTrashPickup : MonoBehaviour
{

    public int valueOfBigTrash = 15;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            FindObjectOfType<GameManager>().AddScore(valueOfBigTrash);
            Destroy(gameObject);
        }
    }
}
