using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScoreCounter : MonoBehaviour
{
    [Header("Dynamic")]
    // b
    public int score = 0;

    private TextMeshProUGUI uiText;
    // c

    void Start()
    {
        uiText = GetComponent<TextMeshProUGUI>();
        // d
    }

    void Update()
    {
        uiText.text = score.ToString("#,0"); // This 0 is azero// e
    }
}