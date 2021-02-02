using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeWalk : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var pos = transform.position;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            pos.x += -1;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            pos.x += 1;
        }

        transform.position = pos;
    }
}
