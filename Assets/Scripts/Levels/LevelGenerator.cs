using UnityEngine;
public class LevelGenerator
{
    private Vector3 nextSpawnPoint;

    public LevelGenerator(Vector3 initialSpawnPoint)
    {
        nextSpawnPoint = initialSpawnPoint;
    }

    public void SpawnPlatform(GameObject platformPrefab)
    {
        GameObject platform = Object.Instantiate(platformPrefab, nextSpawnPoint, Quaternion.identity);
        nextSpawnPoint.x += platform.GetComponent<Collider2D>().bounds.size.x;
    }
}
