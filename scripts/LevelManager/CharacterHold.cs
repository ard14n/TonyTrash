using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHold : MonoBehaviour {

	void OnTriggerEnter(Collider col)
    {
        col.transform.parent = gameObject.transform;
    }

    private void OnTriggerExit(Collider col)
    {
        col.transform.parent = null;
    }
}
