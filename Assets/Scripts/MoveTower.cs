using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MoveTower : MonoBehaviour, IDragHandler, IEndDragHandler, IPointerEnterHandler, IPointerExitHandler
{

    public GameObject moveTower;
    public GameObject intro;
    public Text textIntro;

    bool btnSwitch;

    GameObject parent;
    GameControl gc;

    Vector3 initpos;
    Vector3 towerPos;
    Vector3 mousePos;
    Vector3 move;

    TowerData td;

    private void Start()
    {
        gc = GameObject.Find("GameControl").GetComponent<GameControl>();
        initpos = moveTower.transform.position;
        td = TowerDataManage.getInstance().GetTowerData(moveTower.name, 1);
    }

    private void Update()
    {
        if (gc.playerMoney >= td.cost)
        {
            this.GetComponent<Button>().interactable = true;
        }
        else 
        {
            this.GetComponent<Button>().interactable = false;
        } 
        
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (this.GetComponent<Button>().interactable) 
        {
            //先把需要移动的物体坐标转化为屏幕坐标
            towerPos = Camera.main.WorldToScreenPoint(moveTower.transform.position);
            //把z轴赋值给鼠标坐标的z轴
            mousePos = Input.mousePosition;
            mousePos.z = towerPos.z;

            move = Camera.main.ScreenToWorldPoint(mousePos);
            move.y = 0f;
            moveTower.transform.position = move;
        }
    
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (this.GetComponent<Button>().interactable)
        {
            moveTower.transform.position = initpos;

            if (moveTower.GetComponent<BuildTower>().canBuild)
            {
                parent = moveTower.GetComponent<BuildTower>().parent;
                //如果结束拖动时在地基上，则建塔

                if (gc.playerMoney >= td.cost)//金钱足够
                {
                    gc.ReduceMoney(td.cost);

                    GameObject tower = ObjectPool.getInstance().GetObj("Tower", td.name + td.level);
                    //初始化塔的属性


                    tower.transform.parent = parent.transform;
                    tower.transform.localPosition = Vector3.zero;
                    tower.GetComponent<Tower>().SetTowerData(td);

                    parent.gameObject.GetComponent<BuildPlace>().SetTowerData(td);
                    parent.gameObject.GetComponent<BuildPlace>().SetHasTower(true);
                }
            }
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        intro.SetActive(true);

        textIntro.text = TowerDataManage.getInstance().GetTowerData(moveTower.name, 1).intro;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        intro.SetActive(false);
    }

}
