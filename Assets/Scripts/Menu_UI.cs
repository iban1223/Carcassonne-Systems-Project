using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// UI for scene 0: Menu
public class Menu_UI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickNewGame()
    {
        // check File-- buildSettings for the scene number
        // scene 1 is the initial scene for the game
        SceneManager.LoadScene(1);
    }

    public void OnClickQuit()
    {
        //exit the program at any point
        Application.Quit();
    }
}
