using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraControl : MonoBehaviour
{

    CharacterController cc;


    Vector3 movePos;
    float x_offset;
    float z_offset;
    

    // Start is called before the first frame update
    void Start()
    {
        cc = this.gameObject.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            x_offset = Input.GetAxis("Mouse X");
            z_offset = Input.GetAxis("Mouse Y");
            movePos = new Vector3(-x_offset, 0, -z_offset);
            cc.Move(movePos/2);
        }
    }
}
