using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyMenu : MonoBehaviour
{

    string enemyName;
    string roadName;

    public GameObject Line1Hit;
    public GameObject Line2Hit;
    public GameObject Line3Hit;
    public GameObject EnemyStartPoint;
    public Dropdown dropdown;
    public Text intro_text;
    public Text btn_text;

    GameControl gc;

    // Start is called before the first frame update
    void Start()
    {
        gc = GameObject.Find("GameControl").GetComponent<GameControl>();
        if(GameSettings.getInstance().GameMode == "AttackMode")
            ShowLineHit(Line1Hit);
        roadName = "Line1";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SelectEnemy(string name) 
    {
        enemyName = name;
        EnemyData ed = EnemyDataManage.getInstance().GetEnemyData(enemyName);
        intro_text.text = ed.intro;
        btn_text.text = "召唤$" + ed.cost;
    }

    public void SelectLine() 
    {
        int index = dropdown.value + 1;
        HideLineHit();
        roadName = "Line" + index;
        switch (index) 
        {
            case 1:
                ShowLineHit(Line1Hit);
                break;
            case 2:
                ShowLineHit(Line2Hit);
                break;
            case 3:
                ShowLineHit(Line3Hit);
                break;
        }
    }

    public void HideLineHit() 
    {
        List<GameObject> line1his = Line1Hit.GetComponent<LineHit>().lineHits;
        List<GameObject> line2his = Line2Hit.GetComponent<LineHit>().lineHits;
        List<GameObject> line3his = Line3Hit.GetComponent<LineHit>().lineHits;
        foreach (GameObject lh in line1his)
        {
            lh.SetActive(false);
        }
        foreach (GameObject lh in line2his)
        {
            lh.SetActive(false);
        }
        foreach (GameObject lh in line3his)
        {
            lh.SetActive(false);
        }
    }

    public void ShowLineHit(GameObject linehit) 
    {
        List<GameObject> linehis = linehit.GetComponent<LineHit>().lineHits;
        foreach (GameObject lh in linehis) {
            lh.SetActive(true);
        }
    }

    public void SummonEnemy() 
    {
        if (enemyName != "" && roadName != "") 
        {
            EnemyData ed = EnemyDataManage.getInstance().GetEnemyData(enemyName);
            if (gc.playerMoney >= ed.cost) 
            {
                GameObject enemy = ObjectPool.getInstance().GetObj("Enemy", enemyName);
                enemy.GetComponent<NavMeshAgent>().Warp(EnemyStartPoint.transform.localPosition);
                enemy.transform.parent = EnemyStartPoint.transform;
                enemy.GetComponent<Enemy>().InitData(ed, roadName);

                gc.ReduceMoney(ed.cost);
            }
    
        }
    }
}
