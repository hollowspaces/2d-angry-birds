using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    private GameController gameCon;
    private Scene currentActiveScene;

    // Start is called before the first frame update
    void Start()
    {
        currentActiveScene = SceneManager.GetActiveScene();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadScene(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit Game");
    } 

}
