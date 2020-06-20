using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{

    public int playerHP;
    public int playerMoney;

    public Text hp_text;
    public Text money_text;

    GameObject Enemys;
    GameObject buildPlace;

    // Start is called before the first frame update
    void Start()
    {
        playerHP = 10;
        if (GameSettings.getInstance().GameMode == "DefenseMode")
        {
            playerMoney = 1000;
        }
        else 
        {
            playerMoney = 1000;
        }
        money_text.text = "金钱：" + playerMoney;
        Enemys = GameObject.Find("Enemys");
        buildPlace = GameObject.Find("BuildPlace");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReduceHP() 
    {
        playerHP--;
        hp_text.text = "生命值：" + playerHP;
        if (playerHP == 0)
            GameOver();
    }

    public void ReduceMoney(int num)
    {
        playerMoney -= num;
        money_text.text = "金钱：" + playerMoney;
    }   
    
    public void IncreaseMoney(int num)
    {
        playerMoney += num;
        money_text.text = "金钱：" + playerMoney;
    }

    public void GameOver() 
    {
        Time.timeScale = 0;
        if (GameSettings.getInstance().GameMode == "DefenseMode")
        {
            GameObject.Find("Canvas").GetComponent<UIControl>().GameOver.SetActive(true);
        }
        else 
        {
            print("游戏胜利");
            GameObject.Find("Canvas").GetComponent<UIControl>().Victory.SetActive(true);
        }

    }

    public void Win() 
    {
        Time.timeScale = 0;
        GameObject.Find("Canvas").GetComponent<UIControl>().Victory.SetActive(true);
    }

    public void ReStartGame() 
    {
        //清除波数 把WaveControl的wavenum清零
        Enemys.GetComponent<WaveControl>().ReSetWave();

        //金币生命复原
        playerMoney = 100;
        money_text.text = "金钱：" + playerMoney;
        playerHP = 10;
        hp_text.text = "生命值：" + playerHP;
        //塔复原
        BuildPlace[] bps = buildPlace.GetComponentsInChildren<BuildPlace>();
        Tower[] towers = buildPlace.GetComponentsInChildren<Tower>();
        for (int i = 0; i < bps.Length; i++)
        {
            bps[i].SetHasTower(false);
            bps[i].SetTowerData(null);
        }
        for (int i = 0; i < towers.Length; i++)
        {
            ObjectPool.getInstance().RecycleObj(towers[i].gameObject);
        }
        //敌人复原
        Enemy[] enemys = Enemys.GetComponentsInChildren<Enemy>();
        for (int i = 0; i < enemys.Length; i++) 
        {
            enemys[i].ReSet();
        }
        Time.timeScale = 1;
    }


    public void NextLevle(int level)
    {
        //金币生命复原
        playerMoney = 100;
        money_text.text = "金钱：" + playerMoney;
        playerHP = 10;
        hp_text.text = "生命值：" + playerHP;

        //塔复原
        BuildPlace[] bps = buildPlace.GetComponentsInChildren<BuildPlace>();
        Tower[] towers = buildPlace.GetComponentsInChildren<Tower>();
        for (int i = 0; i < bps.Length; i++)
        {
            bps[i].SetHasTower(false);
            bps[i].SetTowerData(null);
        }
        for (int i = 0; i < towers.Length; i++)
        {
            ObjectPool.getInstance().RecycleObj(towers[i].gameObject);
        }
        //敌人复原
        Enemy[] enemys = Enemys.GetComponentsInChildren<Enemy>();
        for (int i = 0; i < enemys.Length; i++)
        {
            enemys[i].ReSet();
        }



        Time.timeScale = 1;
    }
}
