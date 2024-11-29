using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightControl : MonoBehaviour
{
    // Start is called before the first frame update
    

    float duration  = 3.0f;
    float originalRange;

    Light lt;

    void Start()
    {
        lt = GetComponent<Light>();
        originalRange = lt.range;
        Debug.Log("Range:" + originalRange);
    }

    void Update()
    {
        lt.range = lt.range * (float)0.99999;
    }
}
