using UnityEngine;
public class LevelController
{
    private PlayerController playerController;
    private LevelGenerator levelGenerator;

    public LevelController(PlayerController playerController, GameObject platformPrefab, Vector3 initialSpawnPoint)
    {
        this.playerController = playerController;
        this.levelGenerator = new LevelGenerator(initialSpawnPoint);

        playerController.OnPlayerMoved += () => levelGenerator.SpawnPlatform(platformPrefab);
    }
}
