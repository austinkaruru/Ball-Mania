using UnityEngine;
using UnityEngine.SceneManagement;
public class Ball : MonoBehaviour
{

    bool jump = false;
    Rigidbody rb;
    Transform cameraHolder;
    public AudioSource coinSound;

    bool isGameOver = false;

    [SerializeField] float playerSpeed;
    [SerializeField] float jumpForce;

    Vector3 vec;

    [SerializeField] GameObject[] obstacles;
    [SerializeField] float obstacleDistance;
    [SerializeField] float obstaclePosY;
    [SerializeField] int numberOfObstacles;

    int length;
    

    void buildObstacles(){
        length = obstacles.Length;
        vec.z = 56.4f;
        for (int i = 0; i < numberOfObstacles; i++)  {
            vec.z += obstacleDistance;
            vec.y = Random.Range (-obstaclePosY, obstaclePosY);

            Instantiate(obstacles[Random.Range (0, length)], vec, Quaternion.identity);
        }
    }
    
    void Start()
    {
        rb = GetComponent <Rigidbody> ();
        cameraHolder = Camera.main.transform.parent;

        buildObstacles ();
    }

    
    void Update()
    {
        if (Input.GetKeyUp (KeyCode.W)){
        jump = true;
        }
        if (!isGameOver){
            float playerY = transform.position.y;
            if(playerY < -33f || playerY > 33f){
                isGameOver = true;
                Invoke ("RestartGame", .3f); //Restart function called after 1 sec
            }
        }
    }
    private void OnTriggerEnter(Collider other){
        if(other.gameObject.tag == "Coin"){
            // Increment Points
            GameManager.Instance.CollectCoin();
            Debug.Log("You have :"+ GameManager.Instance.GetCoinsCollected());
            
            //Show User the Point Change
            coinSound.Play();
            //Destroy the object
            //Object Pooling
            Destroy(other.gameObject);
        }
    }
    void FixedUpdate(){
        rb.AddForce(Vector3.forward*playerSpeed*Time.fixedDeltaTime);
        if (jump) {
            rb.AddForce(Vector3.up*jumpForce*1000*Time.fixedDeltaTime);
            jump = false; 
        }
    }
    void LateUpdate(){
        vec.x = cameraHolder.transform.position.x;
        vec.y = cameraHolder.transform.position.y;
        vec.z = transform.position.z;

        cameraHolder.transform.position = vec;
    }
    void OnCollisionEnter(){
        rb.velocity = Vector3.zero; //Player movement stopped
        rb.useGravity = false; //disables gravity
        rb.constraints =  RigidbodyConstraints.FreezeAll;
        GetComponent <MeshRenderer>().enabled = false; //hide the player
        transform.GetChild(1).GetComponent <ParticleSystem>().Play();
        Invoke ("RestartGame", 1f); //Restart function called after 1 sec
    }
    void RestartGame(){
        SceneManager.LoadScene (0); //Reload scene
    }
}
