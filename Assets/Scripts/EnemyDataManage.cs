using LitJson;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class EnemyDataManage
{
    public static EnemyDataManage instance;

    Dictionary<string, EnemyData> allEnemyData;

    private EnemyDataManage() 
    {
        if (File.Exists(Application.persistentDataPath + "/EnemyData.txt"))
        {
            File.Delete(Application.persistentDataPath + "/EnemyData.txt");
            File.Copy(Application.streamingAssetsPath + "/EnemyData.txt", Application.persistentDataPath + "/EnemyData.txt");
        }
        else 
        {
            File.Copy(Application.streamingAssetsPath + "/EnemyData.txt", Application.persistentDataPath + "/EnemyData.txt");
        }

        //读取配置表的信息
        allEnemyData = new Dictionary<string, EnemyData>();

        JsonData enemyList = JsonMapper.ToObject(File.ReadAllText(Application.persistentDataPath + "/EnemyData.txt"));
        for (int i = 0; i < enemyList.Count; i++) 
        {
            JsonData enemy = enemyList[i];
            string name = enemy["name"].ToString();
            float hp = float.Parse(enemy["hp"].ToString());
            float speed = float.Parse(enemy["speed"].ToString());
            int cost = int.Parse(enemy["cost"].ToString());
            int vaule = int.Parse(enemy["vaule"].ToString());
            string intro = enemy["intro"].ToString();
            EnemyData ed = new EnemyData(name, hp, speed, cost, vaule, intro);
            if (allEnemyData.ContainsKey(name))
            {
                
            }
            else 
            {
                allEnemyData.Add(name, ed);

            }
        }
    }

    public static EnemyDataManage getInstance()
    {
        if (instance == null)
        {
            instance = new EnemyDataManage();
        }
        return instance;
    }

    public EnemyData GetEnemyData(string name) 
    {
        return allEnemyData[name];
    }
}
