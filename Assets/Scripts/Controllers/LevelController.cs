using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController 
{
    private PlayerController playerController;
    private LevelGenerator levelGenerator;

    public LevelController(PlayerController playerController, LevelGenerator levelGenerator)
    {
        this.playerController = playerController;
        this.levelGenerator = levelGenerator;

        playerController.OnPlayerMoved += SpawnNextPlatform;
    }

    private void SpawnNextPlatform()
    {
        // Spawn the next platform at a suitable position ahead of the player
        levelGenerator.SpawnPlatform();
    }
}
