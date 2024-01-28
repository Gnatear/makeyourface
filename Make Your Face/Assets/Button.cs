using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManager;

public class Button : MonoBehaviour
{
    [SerializeField] private string newGameLevel1 = "Level1";
    
    public void Button(){

        SceneManager.LoadScene(newGameLevel1);

    }
    
}
