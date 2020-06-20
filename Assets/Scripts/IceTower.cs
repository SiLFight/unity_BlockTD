using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceTower : Tower
{
    // Start is called before the first frame update
    void Start()
    {
        enemys = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Attack(GameObject target)
    {
       
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Enemy")
        {
            //调用敌人减速的方法
            other.gameObject.GetComponent<Enemy>().SetSlowDown(tData.nova);
            other.gameObject.GetComponent<Enemy>().novaEffect.SetActive(true);
        }
    }

    protected override void OnTriggerExit(Collider other)
    {
        if (other.tag == "Enemy")
        {
            //调用敌人恢复速度的方法
            other.gameObject.GetComponent<Enemy>().SetSlowDown(0f);
            other.gameObject.GetComponent<Enemy>().novaEffect.SetActive(false);
        }
    }
}
