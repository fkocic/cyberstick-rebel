using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneWayMovingPlatform : MonoBehaviour
{
    [SerializeField] GameObject platform;
    [SerializeField] Transform originPoint;
    [SerializeField] Transform targetPoint;
    [SerializeField] List<GameObject> cars;

    [SerializeField] float speed = 3;
    [SerializeField] float respawnDelay = 0;
    [SerializeField] float startDelay = 0;
    [SerializeField] float respawnTimer = 0;

    private void Update()
    {
        if (startDelay > 0)
        {
            startDelay -= Time.deltaTime;
            return;
        }

        if (respawnTimer > 0)
        {
            respawnTimer -= Time.deltaTime;
            return;
        }

        if (Mathf.Abs(Vector3.Distance(platform.transform.position, targetPoint.position)) <= 0.005f) {
            platform.transform.position = originPoint.position;
            respawnTimer = respawnDelay;
        }
        Debug.Log("???");
        var step = speed * Time.deltaTime;
        platform.transform.position = Vector3.MoveTowards(platform.transform.position, targetPoint.position, step);
    }
}
