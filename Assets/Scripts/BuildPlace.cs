using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildPlace : MonoBehaviour
{
    private bool hasTower;
    private int towerLevel;
    private TowerData data;

    // Start is called before the first frame update
    void Start()
    {
        hasTower = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetHasTower(bool flag) {
        hasTower = flag;
    }

    public bool HasTower() 
    {
        return hasTower;
    }

    public TowerData GetTowerData() 
    {
        return data;
    }

    public void SetTowerData(TowerData td) 
    {
        data = td;
    }
}
