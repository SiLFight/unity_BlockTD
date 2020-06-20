using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public TowerData tData;
    protected List<GameObject> enemys;
    protected float attackRate;
    public GameObject attackRang;
    public Transform firepos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }



    public virtual void Attack(GameObject target)
    {

    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy") 
        {
            if (other.gameObject != null) 
            {
                enemys.Add(other.gameObject);
                other.gameObject.GetComponent<Enemy>().dieEvent += RemoveEnemy;
            }

        }
    }

    protected virtual void OnTriggerExit(Collider other)
    {
        if (other.tag == "Enemy")
        {
            enemys.Remove(other.gameObject);
        }
    }

    public void SetTowerData(TowerData data) {
        tData = data;
        attackRate = tData.attack_rate;
        attackRang.transform.localScale = new Vector3(tData.rang*2, 0.01f, tData.rang * 2);
        this.gameObject.GetComponent<CapsuleCollider>().radius = tData.rang;
    }

    public void ShowAccatkRang() {
        attackRang.SetActive(true);
    }

    public void HideAccatkRang()
    {
        attackRang.SetActive(false);
    }


    public void RemoveEnemy(GameObject enemy) 
    {
        enemys.Remove(enemy);
    }
}
