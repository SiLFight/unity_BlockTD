using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BigRedSlimeEnemy : Enemy
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
            GameObject slime1 = ObjectPool.getInstance().GetObj("Enemy", "RedSlime");
            GameObject slime2 = ObjectPool.getInstance().GetObj("Enemy", "RedSlime");
            slime1.transform.parent = this.transform.parent;
            slime2.transform.parent = this.transform.parent;
            slime1.GetComponent<NavMeshAgent>().Warp(this.transform.position);
            slime2.GetComponent<NavMeshAgent>().Warp(this.transform.position);
            print(this.transform.position);

            for (int i = 0; i < pastPos.Count; i++)
            {
                myLine.Remove(pastPos[i]);
            }

            slime1.GetComponent<Enemy>().InitData(EnemyDataManage.getInstance().GetEnemyData("RedSlime"), myLine);
            slime2.GetComponent<Enemy>().InitData(EnemyDataManage.getInstance().GetEnemyData("RedSlime"), myLine);
            //slime1.GetComponent<Enemy>().dieEvent += CountDieEnemy;
            //slime2.GetComponent<Enemy>().dieEvent += CountDieEnemy;
        }

        base.Die();
    }
}
