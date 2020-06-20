using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyData 
{
    public string name;
    public float hp;
    public float speed;
    public List<Transform> roadLine;
    public int cost;
    public int vaule;
    public string intro;


    public EnemyData(string name, float hp, float speed, int cost, int vaule, string intro) 
    {
        this.name = name;
        this.hp = hp;
        this.speed = speed;
        this.cost = cost;
        this.vaule = vaule;
        this.intro = intro;
    }
    /*
    public void SetRoad(string roadName) {
        this.roadLine = GameObject.Find(roadName).GetComponent<RoadLine>().checkPoints;
    }*/
}
