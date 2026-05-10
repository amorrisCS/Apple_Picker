using System.Collections;
using System.Collections.Generic;
using System.Security.AccessControl;
using UnityEngine;
using UnityEngine.InputSystem;

public class Basket : MonoBehaviour
{

    public ScoreCounter scoreCounter;
    void Start()
    {
        GameObject scoreGO = GameObject.Find("ScoreCounter");
        scoreCounter = scoreGO.GetComponent<ScoreCounter>();
    }
    void Update()
    {
        // Get the current screen position of the mouse from Input
        Vector3 mousePos2D = Mouse.current.position.ReadValue();
        // a
        // The Camera’s z position sets how far to push the mouse into 3D
        // If this line causes a NullReferenceException, select the Main Camera
        // in the Hierarchy and set its tag to MainCamera in the Inspector.
        mousePos2D.z = -Camera.main.transform.position.z;
        // b

        // Convert the point from 2D screen space into 3D game world space
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D); // c

        // Move the x position of this Basket to the x position of the Mouse
        Vector3 pos = this.transform.position;
        pos.x = Mathf.Clamp(mousePos3D.x, -24f, 24f);
        this.transform.position = pos;
    }

    void OnCollisionEnter(Collision coll)
    {
        GameObject collidedWith = coll.gameObject;

        if (collidedWith.CompareTag("Apple"))
        {
            Destroy(collidedWith);
            scoreCounter.score += 100;
            HighScore.TRY_SET_HIGH_SCORE(scoreCounter.score);
        }
        else if (collidedWith.CompareTag("BadApple"))
        {
            Destroy(collidedWith);

            ApplePicker apScript = Camera.main.GetComponent<ApplePicker>();

            apScript.AppleMissed();
        }
    }
}
