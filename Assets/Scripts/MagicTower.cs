using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicTower : Tower
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
        GameObject bullet = ObjectPool.getInstance().GetObj("Bullet", "MagicBullet");
        bullet.transform.localPosition = firepos.position;
        bullet.GetComponent<Bullet>().SetDamage(tData.damage);
        bullet.GetComponent<Bullet>().SetTarget(target);
    }
}
