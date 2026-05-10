using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadApple : MonoBehaviour
{
    // a
    public static float bottomY = -20f;
    // b

    void Start()
    {
        Debug.Log("Apple called");

    }
    void Update()
    {
        if (transform.position.y < bottomY)
        {
            Destroy(this.gameObject);
        }
    }
}