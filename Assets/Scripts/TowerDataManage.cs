using LitJson;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class TowerDataManage
{
    public static TowerDataManage instance;

    Dictionary<string, List<TowerData>> allTowerData;

    private TowerDataManage() 
    {
        if (File.Exists(Application.persistentDataPath + "/TowerData.txt"))
        {
            File.Delete(Application.persistentDataPath + "/TowerData.txt");
            File.Copy(Application.streamingAssetsPath + "/TowerData.txt", Application.persistentDataPath + "/TowerData.txt");
        }
        else 
        {
            File.Copy(Application.streamingAssetsPath + "/TowerData.txt", Application.persistentDataPath + "/TowerData.txt");
        }
            


        //读取配置表的信息
        allTowerData = new Dictionary<string, List<TowerData>>();

        JsonData towerList = JsonMapper.ToObject(File.ReadAllText(Application.persistentDataPath + "/TowerData.txt"));
        for (int i = 0; i < towerList.Count; i++) 
        {

            JsonData tower = towerList[i];
            string name = tower["name"].ToString();
            float attack_rate = float.Parse(tower["attack_rate"].ToString());
            float damage = float.Parse(tower["damage"].ToString());
            float rang = float.Parse(tower["rang"].ToString());
            float nova = float.Parse(tower["nova"].ToString());
            int level = int.Parse(tower["level"].ToString());
            int cost = int.Parse(tower["cost"].ToString());
            int vaule = int.Parse(tower["vaule"].ToString());
            string intro = tower["intro"].ToString();
            TowerData td = new TowerData(name, attack_rate, damage, rang, nova, level, cost, vaule, intro);
            if (allTowerData.ContainsKey(name))
            {
                allTowerData[name].Add(td);
            }
            else 
            {
                allTowerData.Add(name, new List<TowerData>() { td });
            }
        }
    }

    public static TowerDataManage getInstance()
    {
        if (instance == null)
        {
            instance = new TowerDataManage();
        }
        return instance;
    }

    public TowerData GetTowerData(string name, int level) 
    {
        return allTowerData[name][level - 1];
    }
}
