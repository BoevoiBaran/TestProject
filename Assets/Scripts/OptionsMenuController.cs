using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionsMenuController : MonoBehaviour
{
    private Character character;


    private void Awake()
    {
        character = Resources.Load<Character>("Character");
    }


    public void SetAttackSpeed(float attackSpeed)
    {
        Debug.Log(attackSpeed);
        character.AttackSpeed = attackSpeed;
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }



}
