using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ApplePicker : MonoBehaviour
{
    [Header("Inscribed")]
    public GameObject basketPrefab;
    public int numBaskets = 3;
    public float basketBottomY = -14f;
    public float basketSpacingY = 2f;
    public List<GameObject> basketList;

    void Start()
    {
        basketList = new List<GameObject>();

        for (int i = 0; i < numBaskets; i++)
        {
            GameObject tBasketGO = Instantiate<GameObject>(basketPrefab);
            Vector3 pos = Vector3.zero;
            pos.y = basketBottomY + (basketSpacingY * i);
            tBasketGO.transform.position = pos;
            basketList.Add(tBasketGO);
        }
    }

    public void AppleMissed()
    {
        //delete all objects tagged as apples
        GameObject[] appleArray = GameObject.FindGameObjectsWithTag("Apple");

        GameObject[] badAppleArray = GameObject.FindGameObjectsWithTag("BadApple");

        foreach (GameObject tempGo in appleArray)
        {
            Destroy(tempGo);
        }

        foreach (GameObject tempGo in badAppleArray)
        {
            Destroy(tempGo);
        }

        int basketIndex = basketList.Count - 1;

        GameObject basketGo = basketList[basketIndex];
        basketList.RemoveAt(basketIndex);
        Destroy(basketGo);

        if (basketList.Count == 0)
        {
            SceneManager.LoadScene("_Scene_0");
        }
    }
}