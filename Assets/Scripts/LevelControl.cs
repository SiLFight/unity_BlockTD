using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LevelControl : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        /*
        if (File.Exists(Application.persistentDataPath + "/LevelData.txt"))
        {
            File.Delete(Application.persistentDataPath + "/LevelData.txt");
            File.Copy(Application.streamingAssetsPath + "/LevelData.txt", Application.persistentDataPath + "/LevelData.txt");
        }
        else
        {
            File.Copy(Application.streamingAssetsPath + "/LevelData.txt", Application.persistentDataPath + "/LevelData.txt");
        }
        */
        CannonTower[] cannonTowers = this.GetComponentsInChildren<CannonTower>();

        ElectricTower[] electricTowers = this.GetComponentsInChildren<ElectricTower>();

        IceTower[] iceTowers = this.GetComponentsInChildren<IceTower>();

        MagicTower[] magicTowers = this.GetComponentsInChildren<MagicTower>();


        if (GameSettings.getInstance().GameMode == "DefenseMode")
        {
            foreach (CannonTower ct in cannonTowers)
            {
                ObjectPool.getInstance().RecycleObj(ct.gameObject);
            }
            foreach (ElectricTower et in electricTowers)
            {
                ObjectPool.getInstance().RecycleObj(et.gameObject);
            }
            foreach (IceTower it in iceTowers)
            {
                ObjectPool.getInstance().RecycleObj(it.gameObject);
            }
            foreach (MagicTower mt in magicTowers)
            {
                ObjectPool.getInstance().RecycleObj(mt.gameObject);
            }
        }
        else 
        {
            foreach (CannonTower ct in cannonTowers)
            {
                ct.SetTowerData(TowerDataManage.getInstance().GetTowerData("CannonTower", 3));
            }
            foreach (ElectricTower et in electricTowers)
            {
                et.SetTowerData(TowerDataManage.getInstance().GetTowerData("ElectricTower", 3));
            }
            foreach (IceTower it in iceTowers)
            {
                it.SetTowerData(TowerDataManage.getInstance().GetTowerData("IceTower", 3));
            }
            foreach (MagicTower mt in magicTowers)
            {
                mt.SetTowerData(TowerDataManage.getInstance().GetTowerData("MagicTower", 3));
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
