using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeUpEffect : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.parent.gameObject.GetComponent<Enemy>().HpUp(1 * Time.deltaTime);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Enemy")
        {
            //每秒回1血
            other.gameObject.GetComponent<Enemy>().HpUp(1 * Time.deltaTime);
        }
    }

}
