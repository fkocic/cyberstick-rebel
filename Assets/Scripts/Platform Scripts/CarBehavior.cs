using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarBehavior : MonoBehaviour
{
    [SerializeField] float speed = 4;
    [SerializeField] float killTimer = 200;

    private void Update()
    {
        if (killTimer <= 0) Destroy(gameObject);

        var step = Time.deltaTime * speed;
        transform.position += Vector3.right * step;

        killTimer -= Time.deltaTime;
    }
}
