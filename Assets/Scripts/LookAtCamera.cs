using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    Vector3 targetOrientation;
    Vector3 targetPos;

    // Start is called before the first frame update
    void Start()
    {
       targetOrientation = Camera.main.transform.rotation * Vector3.up;
    }

    // Update is called once per frame
    void Update()
    {
        targetPos = this.transform.position + Camera.main.transform.rotation * Vector3.forward;
        this.transform.LookAt(targetPos, targetOrientation);
    }
}
