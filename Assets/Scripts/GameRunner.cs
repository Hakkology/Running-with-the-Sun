using UnityEngine;
public class GameRunner : MonoBehaviour
{
    public GameObject player;
    public GameObject platformPrefab; 
    public GameObject jumpPlatformPrefab;
    public GameObject blockPlatformPrefab;
    public GameObject treePrefab; 
    public GameObject background;
    public Camera mainCamera;
    public Vector3 initialSpawnPoint;
    float cameraOffset = 2f; 

    private PlayerController playerController;
    private LevelController levelController;
    private CameraController cameraController;
    private BackgroundController backgroundController;

    void Start()
    {
        Animator animator = player.GetComponent<Animator>();
        Rigidbody2D rigidbody = player.GetComponent<Rigidbody2D>();
        Transform transform = player.transform;

        playerController = new PlayerController(animator, rigidbody, transform);
        levelController = new LevelController(playerController, platformPrefab, jumpPlatformPrefab, blockPlatformPrefab, treePrefab, initialSpawnPoint, mainCamera);

        cameraController = new CameraController(transform, cameraOffset, mainCamera);
        backgroundController =  new BackgroundController(mainCamera.transform, background.transform);
    }
    
    void Update()
    {
        playerController.Update();
        cameraController.Update();
        backgroundController.Update();
    }
}
