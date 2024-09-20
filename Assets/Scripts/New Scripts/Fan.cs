using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fan : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up, 60 * Time.deltaTime);
    }
}
