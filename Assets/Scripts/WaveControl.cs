using LitJson;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class WaveControl : MonoBehaviour
{
    List<List<WaveData>> waveDatas;

    public Text waveName;
    public Text num;

    public GameObject LineHit1;
    public GameObject LineHit2;
    public GameObject LineHit3;

    int wavenum;
    int waveEnemyNum;
    int dieEnemyNum;
    int count;

    // Start is called before the first frame update
    void Start()
    {
        if (GameSettings.getInstance().GameMode == "DefenseMode")
        {
            wavenum = 1;
            waveEnemyNum = 0;
            dieEnemyNum = 0;
            count = 20;
            if (File.Exists(Application.persistentDataPath + "/WaveData.txt"))
            {
                File.Delete(Application.persistentDataPath + "/WaveData.txt");
                File.Copy(Application.streamingAssetsPath + "/WaveData.txt", Application.persistentDataPath + "/WaveData.txt");
            }
            else
            {
                File.Copy(Application.streamingAssetsPath + "/WaveData.txt", Application.persistentDataPath + "/WaveData.txt");
            }

            waveDatas = new List<List<WaveData>>();
            JsonData wavelist = JsonMapper.ToObject(File.ReadAllText(Application.persistentDataPath + "/WaveData.txt"));
            for (int i = 0; i < wavelist.Count; i++)
            {
                JsonData wave = wavelist[i];
                List<WaveData> wdlist = new List<WaveData>();
                for (int j = 0; j < wave.Count; j++)
                {
                    string name = wave[j]["name"].ToString();
                    int num = int.Parse(wave[j]["num"].ToString());
                    string road = wave[j]["road"].ToString();
                    float delay = float.Parse(wave[j]["delay"].ToString());
                    wdlist.Add(new WaveData(name, num, road, delay));
                }
                waveDatas.Add(wdlist);
            }

            waveName.text = "第" + wavenum + "波倒计时";

            StartCoroutine(WaveCountDown());
        }
    }

    IEnumerator WaveCountDown() 
    {
       
        while (true) 
        {
            yield return new WaitUntil(() => Time.timeScale != 0);
            if (count == 0) 
            {
                count = 20;
                NextWave();
                if (wavenum > waveDatas.Count)
                {
                    num.text = dieEnemyNum + "/" + waveEnemyNum;
                    waveName.text = "剩余怪物数量:";
                    break;

                }
                waveName.text = "第" + wavenum + "波倒计时";
            }
            yield return new WaitForSeconds(1f / Time.timeScale);
            count--;
            num.text = count.ToString();
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        if (GameSettings.getInstance().GameMode == "DefenseMode")
        {
            if (wavenum > waveDatas.Count)
            {
                num.text = dieEnemyNum + "/" + waveEnemyNum;
            }
            if (dieEnemyNum == waveEnemyNum)
            {
                if (wavenum > waveDatas.Count)
                {
                    //游戏胜利
                    GameObject.Find("GameControl").GetComponent<GameControl>().Win();
                }

            }
        }
            
    }


    public void NextWave()
    {
        List<WaveData> wavelist = waveDatas[wavenum-1];
        for (int i = 0; i < wavelist.Count; i++) {
            WaveData wd = wavelist[i];
            waveEnemyNum += wd.num;
            StartCoroutine(MakeEnemy(wd));
        }
        wavenum++;
    }

    IEnumerator MakeEnemy(WaveData wd) 
    {
        yield return new WaitForSeconds(wd.delay - 5f);
        //提示路线
        if (wd.roadName == "Line1")
        {
            LineHit1.GetComponent<LineHit>().ShowHits();
        }
        else if (wd.roadName == "Line2") 
        {
            LineHit2.GetComponent<LineHit>().ShowHits();
        }
        else if (wd.roadName == "Line3")
        {
            LineHit3.GetComponent<LineHit>().ShowHits();
        }
        yield return new WaitForSeconds(5f);
        //开始刷怪
        for (int i = 0; i < wd.num; i++) 
        {
            GameObject enemy = ObjectPool.getInstance().GetObj("Enemy", wd.enemyName);
            enemy.GetComponent<NavMeshAgent>().Warp(this.transform.localPosition);
            enemy.transform.parent = this.transform;
            enemy.GetComponent<Enemy>().InitData(EnemyDataManage.getInstance().GetEnemyData(wd.enemyName), wd.roadName);
            enemy.GetComponent<Enemy>().dieEvent += CountDieEnemy;
            yield return new WaitForSeconds(0.5f);
        }

    }

    public void CountDieEnemy(GameObject obj) {
        dieEnemyNum++;
    }

    public void ReSetWave() 
    {
        wavenum = 1;
        waveEnemyNum = 0;
        dieEnemyNum = 0;
        count = 20;
        waveName.text = "第" + wavenum + "波倒计时";
        num.text = count.ToString();
        StopAllCoroutines();
        StartCoroutine(WaveCountDown());
    }
}
