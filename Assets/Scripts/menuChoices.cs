using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuChoices : MonoBehaviour
{
    // Start is called before the first frame update
    public void clickPlay(){
        SceneManager.LoadScene("Level 1");
    }

    public void clickQuit(){
        Application.Quit();
    }
}
