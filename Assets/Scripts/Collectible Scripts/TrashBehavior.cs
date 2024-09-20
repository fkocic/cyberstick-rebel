using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashBehavior : MonoBehaviour
{
    [SerializeField] float speed = 5;
    [SerializeField] GameObject detectionSphere;
    [SerializeField] float detectionSphereRadius = 40;
    [SerializeField] Transform playerCoordinates;

    [SerializeField] List<GameObject> trashTypes = new List<GameObject>();

    private bool isFollowingPlayer = false;
    private Vector3 startingCoordinates;

    private void Start()
    {
        Instantiate(trashTypes[Random.Range(0, trashTypes.Count)], transform.position, Quaternion.identity, transform);
        startingCoordinates = transform.position;
        detectionSphere.transform.localScale *= detectionSphereRadius;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            AudioManager.Instance.PlayClang();
            other.gameObject.GetComponent<PlayerMovement>().DecreaseMovementSpeed();
            gameObject.SetActive(false);
            transform.position = startingCoordinates;
            isFollowingPlayer = false;
        }       
    }

    private void Update()
    {
        transform.Rotate(Vector3.up, 60 * Time.deltaTime);

        if (isFollowingPlayer)
        {
            var step = speed * Time.deltaTime;
            if (playerCoordinates != null)
            {
                transform.position = Vector3.MoveTowards(transform.position, playerCoordinates.position, step);
            }
            
        }
    }

    public void StartFollowingPlayer(Transform player)
    {
        playerCoordinates = player;
        isFollowingPlayer = true;
    }

    public void StopFollowingPlayer()
    {
        playerCoordinates = null;
        isFollowingPlayer = false;
    }

    public void ReturnToStartingPosition()
    {
        transform.position = startingCoordinates;
    }
}
