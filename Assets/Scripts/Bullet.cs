using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    private float damage;
    private GameObject Target;
    private float bullet_speed;

    // Start is called before the first frame update
    void Start()
    {
        bullet_speed = 10;
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (Target != null && Target.active != false)
        {
            this.transform.LookAt(Target.transform);
            this.transform.Translate(Vector3.forward * Time.deltaTime * 10);
        }
        else 
        {
            ObjectPool.getInstance().RecycleObj(this.gameObject);
        }
        */
        this.transform.LookAt(Target.transform);
        this.transform.Translate(Vector3.forward * Time.deltaTime * 10  * Time.timeScale);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Target) 
        {
            Target = null;
            //敌人掉血
            other.gameObject.GetComponent<Enemy>().Injure(damage);
            ObjectPool.getInstance().RecycleObj(this.gameObject);
        }
            
    }

    public void SetDamage(float damage) 
    {
        this.damage = damage;
    }

    public void SetTarget(GameObject target) 
    {
        this.Target = target;
        target.GetComponent<Enemy>().dieEvent += HideMyself;
    }

    public void HideMyself(GameObject target) 
    {
        if(this.gameObject.activeSelf)
            ObjectPool.getInstance().RecycleObj(this.gameObject);
    }
}
