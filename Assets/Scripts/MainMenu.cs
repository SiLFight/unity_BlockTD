using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartDefenseGame() 
    {
        GameSettings.getInstance().GameMode = "DefenseMode";
        SceneManager.LoadScene("LoadingScene");
    }

    public void StartAttackGame()
    {
        GameSettings.getInstance().GameMode = "AttackMode";
        SceneManager.LoadScene("LoadingScene");
    }

    public void Quitame()
    {
        Application.Quit();
    }
}
