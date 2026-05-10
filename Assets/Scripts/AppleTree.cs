using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AppleTree : MonoBehaviour
{
    [Header("Inscribed")]

    public GameObject applePrefab;

    public GameObject badApplePrefab;

    //Speed at which the AppleTree moves
    public float speed = 1f;

    // Distance where AppleTree turns around
    public float leftAndRightEdge = 10f;

    // Chance that the AppleTree will change directions
    public float changeDirChance = 0.02f;

    // Seconds between Apples instantiations
    public float appleDropDelay = 1f;

    private LayerMask appleLayer;

    void Start()
    {
        // Start dropping apples
        Invoke("DropApple", 2f);
        Invoke("DropBadApple", Random.Range(0.5f, 6f));
    }

    void DropApple()
    {
        GameObject apple = Instantiate<GameObject>(applePrefab);
        apple.transform.position = transform.position;
        Invoke("DropApple", appleDropDelay);

    }

    void DropBadApple()
    {
        Vector3 spawnPos = transform.position;

        //check if space is occupied at layer Apple
        //the apple has a radius of 0.5f, but we dont want the apples to spawn to close
        float radius = 1.5f;
        bool occupied = Physics.CheckSphere(spawnPos, radius, appleLayer);

        if (!occupied)
        {
            GameObject badApple = Instantiate<GameObject>(badApplePrefab);
            badApple.transform.position = transform.position;
        }


        float delay = Random.Range(0.5f, 6f);
        Invoke("DropBadApple", delay);
    }

    void Update()
    {
        // Basic Movement
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        // Changing Direction
        if (pos.x < -leftAndRightEdge)
        {
            speed = Mathf.Abs(speed); // Move right
        }
        else if (pos.x > leftAndRightEdge)
        {
            speed = -Mathf.Abs(speed); // Move left
        }
    }

    void FixedUpdate()
    {
        if (Random.value < changeDirChance)
        {
            speed *= -1;
        }
    }
}

