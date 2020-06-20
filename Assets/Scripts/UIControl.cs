using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIControl : MonoBehaviour
{

    public GameObject TowerMenu;
    public GameObject UpgradeMenu;
    public GameObject WaveMenu;
    public GameObject EnemyMenu;
    public GameObject GameOver;
    public GameObject Victory;

    public GameObject X2;
    public GameObject X1;

    GameControl gc;


    // Start is called before the first frame update
    void Start()
    {
        X1.SetActive(false);
        X2.SetActive(true);

        if (GameSettings.getInstance().GameMode == "DefenseMode")
        {
            WaveMenu.SetActive(true);
            EnemyMenu.SetActive(false);
            Time.timeScale = 1;
        }
        else 
        {
            WaveMenu.SetActive(false);
            EnemyMenu.SetActive(true);
            Time.timeScale = 1;
        }

        gc = GameObject.Find("GameControl").GetComponent<GameControl>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void X2Speed() 
    {
        Time.timeScale = 1.25f;
        X1.SetActive(true);
        X2.SetActive(false);
    }

    public void X1Speed()
    {
        Time.timeScale = 1;
        X1.SetActive(false);
        X2.SetActive(true);
    }

    public void ReStartGame() 
    {
        X1.SetActive(false);
        X2.SetActive(true);
        GameObject.Find("GameControl").GetComponent<GameControl>().ReStartGame();
        GameOver.SetActive(false);
    }

    public void Back()
    {
        ObjectPool.getInstance().ReStatr();
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }

    public void NextLevel(int level) 
    {
        gc.NextLevle(level);
    }
}
