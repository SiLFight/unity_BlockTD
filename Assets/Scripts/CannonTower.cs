using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonTower : Tower
{


    // Start is called before the first frame update
    void Start()
    {
        enemys = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        attackRate += Time.deltaTime * Time.timeScale;
        if (enemys.Count > 0)
        {
            this.gameObject.transform.LookAt(new Vector3(enemys[0].transform.position.x, transform.localPosition.y, enemys[0].transform.position.z));
        }
        if (attackRate >= tData.attack_rate && enemys.Count > 0)
        {
            /*
            for (int i = 0; i < enemys.Count; i++)
            {
                if (!enemys[i].active)
                    enemys.Remove(enemys[i]);
            }
            */
            if (enemys.Count > 0)
            {
                attackRate = 0;
                Attack(enemys[0]);
            }
        }
    }

    public override void Attack(GameObject target)
    {
        GameObject bullet = ObjectPool.getInstance().GetObj("Bullet", "CannonBullet");
        bullet.transform.localPosition = firepos.position;
        bullet.GetComponent<Bullet>().SetDamage(tData.damage);
        bullet.GetComponent<Bullet>().SetTarget(target);
    }
}
