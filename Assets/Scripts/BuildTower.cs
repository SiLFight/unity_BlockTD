using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildTower : MonoBehaviour
{
    public bool canBuild;
    public GameObject parent;

    // Start is called before the first frame update
    void Start()
    {
        canBuild = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Build")
        {
            parent = other.gameObject;
            if (!parent.GetComponent<BuildPlace>().HasTower()) 
            {
                canBuild = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Build")
        {
            canBuild = false;
            parent = null;
        }
    }
}
