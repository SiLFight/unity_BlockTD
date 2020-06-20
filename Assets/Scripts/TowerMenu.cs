using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerMenu : MonoBehaviour
{
    /*
    public Text textIntro;
    public GameObject tower_CannonTower;
    public GameObject tower_IceTower;
    public GameObject tower_ElectricTower;
    public GameObject tower_MagicTower;

    Vector3 tower_initpos;
    Transform parent;
    string path;
    string name;
    GameControl gc;
    */
    // Start is called before the first frame update
    void Start()
    {
        if (GameSettings.getInstance().GameMode == "DefenseMode")
        {
            this.gameObject.SetActive(true);
        }
        else 
        {
            this.gameObject.SetActive(false);
        }
        /*
        tower_initpos = new Vector3(-20, 0, -20);
        path = "Tower";
        name = "";
        gc = GameObject.Find("GameControl").GetComponent<GameControl>();
        */
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /*
    public void GetParentTransform(Transform parent) {
        
        this.parent = parent;
    }

    public void ResetTowerPos() {
        tower_initpos = new Vector3(-20, 0, -20);
        tower_CannonTower.transform.localPosition = tower_initpos;
        tower_IceTower.transform.localPosition = tower_initpos;
        tower_ElectricTower.transform.localPosition = tower_initpos;
        tower_MagicTower.transform.localPosition = tower_initpos;
    }

    public void ShowCannonTower() {
        name = "CannonTower";
        textIntro.text = makeIntroText(TowerDataManage.getInstance().GetTowerData(name, 1), "火炮塔");
        ResetTowerPos();
        tower_CannonTower.transform.localPosition = parent.localPosition;
    }
    public void ShowIceTower()
    {
        name = "IceTower";
        textIntro.text = makeIntroText(TowerDataManage.getInstance().GetTowerData(name, 1), "减速塔，范围14%减速");
        ResetTowerPos();
        tower_IceTower.transform.localPosition = parent.localPosition;
    }
    public void ShowElectricTower()
    {
        name = "ElectricTower";
        textIntro.text = makeIntroText(TowerDataManage.getInstance().GetTowerData(name, 1), "电塔,AOE");
        ResetTowerPos();
        tower_ElectricTower.transform.localPosition = parent.localPosition;
    }
    public void ShowMagicTower()
    {
        name = "MagicTower";
        textIntro.text = makeIntroText(TowerDataManage.getInstance().GetTowerData(name, 1), "魔法塔");
        
        ResetTowerPos();
        tower_MagicTower.transform.localPosition = parent.localPosition;
    }

    public void Cancel() {
        ResetTowerPos();
        this.gameObject.SetActive(false);
    }

    public void Build() {
        if (name != null && name != "") 
        {
            TowerData td = TowerDataManage.getInstance().GetTowerData(name, 1);
            if (gc.playerMoney >= td.cost)//金钱足够
            {
                ResetTowerPos();
                gc.ReduceMoney(td.cost);

                 GameObject tower = ObjectPool.getInstance().GetObj(path, name + td.level);
                //初始化塔的属性
                
                
                tower.transform.parent = parent;
                tower.transform.localPosition = Vector3.zero;
                tower.GetComponent<Tower>().SetTowerData(td);

                parent.gameObject.GetComponent<BuildPlace>().SetTowerData(td);
                parent.gameObject.GetComponent<BuildPlace>().SetHasTower(true);
                this.gameObject.SetActive(false);
            }
            else 
            {
                //金币不够，弹窗提示
            }

        }

    }

    public string makeIntroText(TowerData td, string name) 
    {
        return name + "，攻速：" + td.attack_rate + "秒/次，伤害：" + td.damage + ",费用：$" + td.cost;
    }
    */
}
