using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerData
{
    public string name;
    public float attack_rate;
    public float damage;
    public float rang;
    public float nova;
    public int level;
    public int cost;
    public int vaule;
    public string intro;
   

    public TowerData(string name, float attack_rate, float damage, float rang, float nova, int level, int cost, int vaule, string intro) {
        this.name = name;
        this.attack_rate = attack_rate;
        this.damage = damage;
        this.rang = rang;
        this.nova = nova;
        this.level = level;
        this.cost = cost;
        this.vaule = vaule;
        this.intro = intro;
    }
}
