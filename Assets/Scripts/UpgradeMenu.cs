using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeMenu : MonoBehaviour
{

    public Text CLevel;
    public Text CAccatk;
    public Text CRate;
    public Text CRang;
    public Text CNova;
    public Text NLevel;
    public Text NAccatk;
    public Text NRate;
    public Text NRang;
    public Text NNova;
    public Text UpgradeText;
    public Text SaleText;
    public GameObject Upgrade;

    Transform parent;

    TowerData current;
    TowerData next;
    GameControl gc;

    // Start is called before the first frame update
    void Start()
    {
        gc = GameObject.Find("GameControl").GetComponent<GameControl>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GetParentTransform(Transform parent)
    {

        this.parent = parent;
    }


    public void InitText(TowerData current, TowerData next) {
        this.current = current;
        this.next = next;

        CLevel.text = "Level " + current.level;
        CAccatk.text = current.damage.ToString();
        CRate.text = current.attack_rate.ToString();
        CRang.text = current.rang.ToString();
        CNova.text = ((int)(current.nova*100)).ToString();

        SaleText.text = "卖出：$" + current.vaule;

        if (next == null)
        {
            string s = "已满级";
            NLevel.text = s;
            NAccatk.text = s;
            NRate.text = s;
            NRang.text = s;
            NNova.text = s;
        }
        else 
        {
            UpgradeText.text = "升级：$" + next.cost;
            NLevel.text = "Level " + next.level;
            NAccatk.text = next.damage.ToString();
            NRate.text = next.attack_rate.ToString();
            NRang.text = next.rang.ToString();
            NNova.text = ((int)(next.nova * 100)).ToString();
        }


    }

    public void UpgradeTower() 
    {
        if (gc.playerMoney >= next.cost)//金钱足够
        {
            gc.ReduceMoney(next.cost);

            GameObject oldTower = parent.GetComponentInChildren<Tower>().gameObject;
            oldTower.GetComponent<Tower>().HideAccatkRang();
            ObjectPool.getInstance().RecycleObj(oldTower);
            GameObject newTower = ObjectPool.getInstance().GetObj("Tower", next.name + next.level);

            newTower.transform.parent = parent;
            newTower.transform.localPosition = Vector3.zero;
            newTower.GetComponent<Tower>().SetTowerData(next);

            parent.gameObject.GetComponent<BuildPlace>().SetTowerData(next);
            parent.gameObject.GetComponent<BuildPlace>().SetHasTower(true);
            this.gameObject.SetActive(false);
        }
    }

    public void SaleTower()
    {
        gc.IncreaseMoney(current.vaule);

        GameObject oldTower = parent.GetComponentInChildren<Tower>().gameObject;
        oldTower.GetComponent<Tower>().HideAccatkRang();
        ObjectPool.getInstance().RecycleObj(oldTower);
        parent.gameObject.GetComponent<BuildPlace>().SetHasTower(false);
        this.gameObject.SetActive(false);

    }

    public void Cancel()
    {
        this.gameObject.SetActive(false);
    }

    public void HideUpgrade() 
    {
        Upgrade.SetActive(false);
    }

    public void ShowUpgrade()
    {
        Upgrade.SetActive(true);
    }
}
