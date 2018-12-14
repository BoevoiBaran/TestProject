using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackSpeedText : MonoBehaviour
{
    private Text attackParamText;

    private void Awake()
    {
        attackParamText = GetComponent<Text>();
    }

    private void Start()
    {
        
    }


    public void TextUpdate( float value)
    {
        attackParamText.text = "Attack Speed: " + value.ToString();
    }

}
