using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesPanel : MonoBehaviour
{
    private Character character;
    private Text livesText;

    private void Awake()
    {
        livesText = GetComponent<Text>();
        character = FindObjectOfType<Character>();
    }

    private void Start()
    {
        Refresh();
    }

    public void Refresh()
    {
        livesText.text = "Lives: " + character.Lives.ToString();
    }
}
