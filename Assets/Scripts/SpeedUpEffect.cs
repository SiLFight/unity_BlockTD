using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpEffect : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.parent.gameObject.GetComponent<Enemy>().SetSpeedUp(0.25f);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Enemy")
        {
            other.gameObject.GetComponent<Enemy>().SetSpeedUp(0.25f);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Enemy")
        {
            other.gameObject.GetComponent<Enemy>().SetSpeedUp(0f);
        }
    }
}
