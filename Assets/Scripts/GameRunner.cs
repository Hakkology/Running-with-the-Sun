using UnityEngine;
public class GameRunner : MonoBehaviour
{
    public GameObject player;
    public GameObject platformPrefab; 
    public GameObject jumpPlatformPrefab;
    public GameObject blockPlatformPrefab;
    public Vector3 initialSpawnPoint;

    private PlayerController playerController;
    private LevelController levelController;

    void Start()
    {
        Animator animator = player.GetComponent<Animator>();
        Rigidbody2D rigidbody = player.GetComponent<Rigidbody2D>();
        Transform transform = player.transform;

        playerController = new PlayerController(animator, rigidbody, transform);
        levelController = new LevelController(playerController, platformPrefab, initialSpawnPoint);
    }
    
    void Update()
    {
        playerController.Update();
    }
}
