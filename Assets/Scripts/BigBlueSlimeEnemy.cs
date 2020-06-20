using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BigBlueSlimeEnemy : Enemy
{
    // Start is called before the first frame update
    void Start()
    {
        InitAnim();
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyData != null)
        {
            if (navMeshAgent != null)
            {
                navMeshAgent.speed = nowSpeed;
            }
            if (nowHP <= 0)
            {
                Die();
            }
        }
    }

    public override void Die()
    {
        if (nowHP <= 0) 
        {
            GameObject slime1 = ObjectPool.getInstance().GetObj("Enemy", "BlueSlime");
            GameObject slime2 = ObjectPool.getInstance().GetObj("Enemy", "BlueSlime");
            GameObject slime3 = ObjectPool.getInstance().GetObj("Enemy", "BlueSlime");
            slime1.transform.parent = this.transform.parent;
            slime2.transform.parent = this.transform.parent;
            slime3.transform.parent = this.transform.parent;
            slime1.GetComponent<NavMeshAgent>().Warp(this.transform.position);
            slime2.GetComponent<NavMeshAgent>().Warp(this.transform.position);
            slime3.GetComponent<NavMeshAgent>().Warp(this.transform.position);

            for (int i = 0; i < pastPos.Count; i++)
            {
                myLine.Remove(pastPos[i]);
            }

          
            slime1.GetComponent<Enemy>().InitData(EnemyDataManage.getInstance().GetEnemyData("BlueSlime"), myLine);
            slime2.GetComponent<Enemy>().InitData(EnemyDataManage.getInstance().GetEnemyData("BlueSlime"), myLine);
            slime3.GetComponent<Enemy>().InitData(EnemyDataManage.getInstance().GetEnemyData("BlueSlime"), myLine);
            //slime1.GetComponent<Enemy>().dieEvent += CountDieEnemy;
            //slime2.GetComponent<Enemy>().dieEvent += CountDieEnemy;
        }

        base.Die();
    }
}
