using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void FixedUpdate()
    {        
        transform.Rotate(new Vector3(0, 0, 20) * Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0,0,20) * Time.deltaTime);
    }
}
