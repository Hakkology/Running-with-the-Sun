using System;
using UnityEngine;

public class LevelGenerator
{
    private Transform playerTransform;
    private Camera mainCamera;
    private float spawnDistance;
    private float platformWidth;
    private float platformHeight = 1.0f;
    private Vector3 nextSpawnPoint;
    private int jumpPlatformCounter = 0;
    private float lastJumpPlatformX = float.NegativeInfinity;
    private float lastTreeX = float.NegativeInfinity;
    private float lastPlatformX = float.NegativeInfinity;
    


    public LevelGenerator(Transform playerTransform, Camera mainCamera, float platformWidth)
    {
        this.playerTransform = playerTransform;
        this.mainCamera = mainCamera;
        this.platformWidth = platformWidth;

        spawnDistance = mainCamera.aspect * mainCamera.orthographicSize + platformWidth * 1.5f;
    }

    public GameObject SpawnPlatform(GameObject platformPrefab)
    {
        Vector3 platformPosition = new Vector3(playerTransform.position.x + spawnDistance, 0f, playerTransform.position.z);
        GameObject platform = UnityEngine.Object.Instantiate(platformPrefab, platformPosition, Quaternion.identity);
        lastPlatformX = platformPosition.x;
        nextSpawnPoint.x = lastPlatformX + platformPrefab.GetComponent<Collider2D>().bounds.size.x;
        return platform;
    }

    public GameObject SpawnJumpPlatform(GameObject jumpPlatformPrefab)
    {
        if (lastPlatformX - lastJumpPlatformX >= UnityEngine.Random.Range(6, 15))
        {
            Vector3 jumpPlatformPosition = new Vector3(lastPlatformX, platformHeight, 0f);
            GameObject platform = UnityEngine.Object.Instantiate(jumpPlatformPrefab, jumpPlatformPosition, Quaternion.identity);
            lastJumpPlatformX = lastPlatformX;
            jumpPlatformCounter++;
            return platform;
        }
        return null;
    }

    public GameObject SpawnBlockPlatform(GameObject blockPlatformPrefab)
    {
        if (jumpPlatformCounter >= 3)
        {
            Vector3 blockPlatformPosition = new Vector3(nextSpawnPoint.x, 0f, 0f);
            GameObject platform = UnityEngine.Object.Instantiate(blockPlatformPrefab, blockPlatformPosition, Quaternion.identity);
            jumpPlatformCounter = 0;
            return platform;
        }

        return null;
    }

    public GameObject SpawnTree(GameObject treePrefab)
    {
        if (lastPlatformX - lastTreeX >= UnityEngine.Random.Range(4, 9))
        {
            Vector3 treePosition = new Vector3(lastPlatformX, platformHeight, 0f);
            GameObject tree = UnityEngine.Object.Instantiate(treePrefab, treePosition, Quaternion.identity);
            lastTreeX = lastPlatformX;
            return tree;
        }
        return null;
    }
}
