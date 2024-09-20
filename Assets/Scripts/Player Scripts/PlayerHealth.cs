using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] Vector3 spawnPosition;
    [SerializeField] LevelManager levelManager;
    [SerializeField] ParticleSystem explosion;

    private PlayerMovement playerMovement;
    private PlayerTrashManager playerTrashManager;
    private MeshRenderer meshRenderer;

    

    private void Start()
    {
        spawnPosition = transform.position;
        playerMovement = GetComponent<PlayerMovement>();
        playerTrashManager = GetComponent<PlayerTrashManager>();
        meshRenderer = GetComponent<MeshRenderer>();
    }

    public void SetCheckpoint(Transform checkpoint)
    {
        spawnPosition = checkpoint.position;
    }

    public void Die()
    {
        if (playerMovement.isDying) return;
        AudioManager.Instance.PlayBoom();
        playerMovement.deathCoordinates = transform.position;
        Debug.Log("Game Over");
        StartCoroutine(KMS());
    }

    IEnumerator KMS()
    {
        playerMovement.isDying = true;
        Explode();
        playerTrashManager.RemoveAllTrash();
        meshRenderer.enabled = false;
        yield return new WaitForSeconds(1);

        transform.position = spawnPosition;
        playerMovement.isDying = false;
        meshRenderer.enabled = true;
        playerMovement.ResetVelocity();
        playerMovement.ResetJumpHeight();
        playerMovement.ResetJumpLevel();
        levelManager.ResetLevel();
    }

    private void Explode()
    {
        explosion.Play();
    }
}
