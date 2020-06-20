using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveData 
{
    public string enemyName;
    public int num;
    public string roadName;
    public float delay;

    public WaveData(string enemyName, int num, string roadName, float delay) 
    {
        this.enemyName = enemyName;
        this.num = num;
        this.roadName = roadName;
        this.delay = delay;
    }
        
}
