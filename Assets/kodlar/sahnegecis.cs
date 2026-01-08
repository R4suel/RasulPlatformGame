using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sahnegecis : MonoBehaviour
{
    public void game()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("game");
        
    }
}
