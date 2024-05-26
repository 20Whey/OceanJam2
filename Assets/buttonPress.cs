using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttonPress : MonoBehaviour
{
    // Start is called before the first frame update
     public void Press()
    {
        SceneManager.LoadScene("GameScene");
        Debug.Log("bruh");
    }

   
}
