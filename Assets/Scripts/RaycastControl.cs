using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RaycastControl : MonoBehaviour
{

    Ray click_ray;
    RaycastHit hit;//存储发射射线后产生的碰撞信息
    private LayerMask mask;
    GameObject oldBP;

    public UIControl uiControl;

    //下面是用来UI事件和射线
    EventSystem eventSystem;
    public GraphicRaycaster RaycastInCanvas;//Canvas上有这个组件

    // Start is called before the first frame update
    void Start()
    {
        mask = 1 << (LayerMask.NameToLayer("BulidLayer"));//实例化mask到BuildTower这个自定义的层级之上。
    }

    // Update is called once per frame
    void Update()
    {
        if (GameSettings.getInstance().GameMode == "DefenseMode") 
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (!CheckGuiRaycastObjects())
                {
                    click_ray = Camera.main.ScreenPointToRay(Input.mousePosition);//把鼠标点击的位置转化成射线
                    if (Physics.Raycast(click_ray, out hit, 100, mask))
                    {

                        if (oldBP != null && oldBP.GetComponent<BuildPlace>().HasTower())
                        {
                            oldBP.GetComponentInChildren<Tower>().HideAccatkRang();
                        }
                        if (hit.transform.gameObject.name == "BP")
                        {

                            if (hit.collider.gameObject.GetComponent<BuildPlace>().HasTower())
                            {
                                hit.collider.gameObject.GetComponentInChildren<Tower>().ShowAccatkRang();
                                TowerData current = hit.collider.gameObject.GetComponent<BuildPlace>().GetTowerData();
                                TowerData next = null;
                                if (current.level == 3)
                                {
                                    //已经满级
                                    uiControl.UpgradeMenu.GetComponent<UpgradeMenu>().HideUpgrade();
                                }
                                else
                                {
                                    next = TowerDataManage.getInstance().GetTowerData(current.name, current.level + 1);
                                    uiControl.UpgradeMenu.GetComponent<UpgradeMenu>().ShowUpgrade();
                                }
                                uiControl.UpgradeMenu.GetComponent<UpgradeMenu>().InitText(current, next);
                                uiControl.UpgradeMenu.GetComponent<UpgradeMenu>().GetParentTransform(hit.transform);
                                uiControl.UpgradeMenu.SetActive(true);
                               // uiControl.TowerMenu.SetActive(false);

                            }
                            else
                            {
                                //uiControl.TowerMenu.GetComponent<TowerMenu>().GetParentTransform(hit.transform);
                                //uiControl.TowerMenu.GetComponent<TowerMenu>().ResetTowerPos();
                                //uiControl.TowerMenu.SetActive(true);
                                //uiControl.UpgradeMenu.SetActive(false);
                            }
                            oldBP = hit.transform.gameObject;
                        }
                        else
                        {
                            //不是地基就把菜单隐藏
                            uiControl.UpgradeMenu.SetActive(false);
                            //uiControl.TowerMenu.SetActive(false);
                           // uiControl.TowerMenu.GetComponent<TowerMenu>().ResetTowerPos();

                        }
                        return;
                    }
                }
            }
        }
    }

    bool CheckGuiRaycastObjects()//测试UI射线
    {
        PointerEventData eventData = new PointerEventData(eventSystem);
        eventData.pressPosition = Input.mousePosition;
        eventData.position = Input.mousePosition;
        List<RaycastResult> list = new List<RaycastResult>();
        RaycastInCanvas.Raycast(eventData, list);
        //Debug.Log(list.Count);
        return list.Count > 0;
    }
}
