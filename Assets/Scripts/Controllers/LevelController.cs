using UnityEngine;
public class LevelController
{
    private PlayerController playerController;
    private LevelGenerator levelGenerator;

    public LevelController(PlayerController playerController, GameObject platformPrefab, GameObject jumpPlatformPrefab, 
    GameObject blockPlatformPrefab, GameObject treePrefab, Vector3 initialSpawnPoint, Camera mainCamera)
    {
        this.playerController = playerController;
        this.levelGenerator = new LevelGenerator(playerController.Transform, mainCamera, platformPrefab.GetComponent<Collider2D>().bounds.size.x);

        playerController.OnPlayerMoved += () =>{
            levelGenerator.SpawnPlatform(platformPrefab);
        };

        playerController.OnPlayerMovedTrees += () =>{
            levelGenerator.SpawnTree(treePrefab);
        };

        playerController.OnPlayerMovedJumpPlatforms += () => {

            levelGenerator.SpawnJumpPlatform(jumpPlatformPrefab);
            levelGenerator.SpawnBlockPlatform(blockPlatformPrefab);
        };
    }
}
