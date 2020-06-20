using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyRotation : MonoBehaviour
{
    float y;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        y += Time.deltaTime * 50;
        if (y > 360f) {
            y = y - 360f;
        }
        transform.rotation = Quaternion.Euler(0, y, 0);
    }
}
