using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class goBackToMenu : MonoBehaviour
{
    // Start is called before the first frame update
    
    // Update is called once per frame
    public void clickFunc()
    {
        SceneManager.LoadScene("Starting Menu");
    }
}
