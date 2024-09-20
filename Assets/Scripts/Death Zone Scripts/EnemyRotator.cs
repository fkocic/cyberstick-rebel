using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRotator : MonoBehaviour
{
    
    void Update()
    {
        transform.Rotate(Vector3.up, 60 * Time.deltaTime);
    }
}
