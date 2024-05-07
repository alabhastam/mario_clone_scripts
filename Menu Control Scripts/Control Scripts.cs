using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlScripts : MonoBehaviour
{
    public void PlayGame(){
        SceneManager.LoadScene("Gameplay");
    } 
}
