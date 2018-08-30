using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Größe der Platform verändert sich.
 * Quelle: https://www.youtube.com/watch?v=GB5mKBALeZw
 **/

public class ChangeSize : MonoBehaviour
{

    public Vector3 minScale;
    public Vector3 maxScale;
    public bool repeat;
    public float speed = 2f;
    public float duration = 5f;

    IEnumerator Start()
    {
        minScale = transform.localScale;
        while (repeat)
        {
            yield return Repeat(maxScale, minScale, duration);
            yield return Repeat(minScale, maxScale, duration);
            

        }
    }

    public IEnumerator Repeat(Vector3 a, Vector3 b, float time)
    {
        float i = 0.0f;
        float rate = (1.0f / time) * speed;
        while(i < 1.0f)
        {
            i += Time.deltaTime * rate;
            transform.localScale = Vector3.Lerp(a, b, i);
            yield return null;
        }
    }

}

  
