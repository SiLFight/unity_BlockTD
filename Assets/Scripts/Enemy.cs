using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float nowHP;
    public float nowSpeed;
    public EnemyData enemyData;

    public List<Transform> myLine;
    public NavMeshAgent navMeshAgent;
    public List<Transform> pastPos;
    public GameObject novaEffect;
    public Slider hpSlider;

    float slowDownPer;
    float speedUpPer;

    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        slowDownPer = 0;
        speedUpPer = 0;
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

    public delegate void IDie(GameObject enemy);
    public IDie dieEvent;

    public virtual void Die()
    {
        if (dieEvent != null) {
            dieEvent(this.gameObject);
        }
        if (nowHP <= 0)
        {
            GameObject.Find("GameControl").GetComponent<GameControl>().IncreaseMoney(enemyData.vaule);
        }
        ObjectPool.getInstance().RecycleObj(this.gameObject);
        StopAllCoroutines();
    }

    public void InitData(EnemyData enemyData, string roadName) 
    {
        List<Transform> pos = GameObject.Find(roadName).GetComponent<RoadLine>().checkPoints;
        myLine = new List<Transform>();
        for (int i = 0; i < pos.Count; i++) 
        {
            myLine.Add(pos[i]);
        }
        print("checkPoints=" + GameObject.Find(roadName).GetComponent<RoadLine>().checkPoints.Count);
        print("initmyline=" + myLine.Count);
        Init(enemyData);
    }

    public void Init(EnemyData enemyData) 
    {
        dieEvent = null;
        this.enemyData = enemyData;
        this.nowHP = enemyData.hp;
        this.nowSpeed = enemyData.speed;
        this.navMeshAgent = this.gameObject.GetComponent<NavMeshAgent>();
        novaEffect.SetActive(false);
        slowDownPer = 0;
        speedUpPer = 0;
        InitAnim();
        StartCoroutine(Move());
    }

    public void InitData(EnemyData enemyData, List<Transform> myLine)
    {
        this.myLine = new List<Transform>();
        for (int i = 0; i < myLine.Count; i++)
        {
            this.myLine.Add(myLine[i]);
        }
        Init(enemyData);
    }

    public IEnumerator Move() {
        pastPos = new List<Transform>();
        for (int i = 0; i < myLine.Count; i++)
        {
            navMeshAgent.SetDestination(myLine[i].localPosition);
            yield return new WaitUntil(ArriveDestination);
            pastPos.Add(myLine[i]);
        }
        GameObject.Find("GameControl").GetComponent<GameControl>().ReduceHP();
        Die();
    }

    public bool ArriveDestination()
    {
        return ((!navMeshAgent.pathPending) && (navMeshAgent.remainingDistance < 0.5f));
    }

    public void SetSlowDown(float speedper)
    {
        if (slowDownPer < speedper)
        {
            slowDownPer = speedper;
        }
        if (speedper == 0)
            slowDownPer = speedper;
    }

    public void RestoreSpeed()
    {
        nowSpeed = enemyData.speed;
    }

    public float Injure(float injure) {
        return nowHP -= injure;
    }

    public void HpUp(float upnum) 
    {
        if(nowHP > 0)
            nowHP += upnum;
    }

    public void SetSpeedUp(float speedper) 
    {
        speedUpPer = speedper;

    }

    public void ChangeSpeed() 
    {
        nowSpeed = (enemyData.speed *Time.timeScale) * (1 - slowDownPer + speedUpPer);
        print("enemyData.speed=" + enemyData.speed);
        print("Time.timeScale=" + Time.timeScale);
        print("slowDownPer=" + slowDownPer);
        print("speedUpPer=" + speedUpPer);
    }

    private void LateUpdate()
    {
        ChangeSpeed();
        if (enemyData != null) 
        {
            hpSlider.value = nowHP / enemyData.hp;
        }
       
    }

    public void InitAnim() 
    {
        animator = this.gameObject.GetComponent<Animator>();
        if (this.gameObject.name.Contains("Slime"))
        {
            animator.Play("WalkFWD1");
        }
        else if (this.gameObject.name == "DogFM" || this.gameObject.name == "EliteDogFM")
        {
            animator.Play("WalkForwardBattle1");
        }
        else 
        {
            animator.Play("Walk1");
        }
    }

    public void ReSet() 
    {
        dieEvent = null;
        ObjectPool.getInstance().RecycleObj(this.gameObject);
        StopAllCoroutines();
    }
}
