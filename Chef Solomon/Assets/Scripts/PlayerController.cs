
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private GameManager gameManager;

    public float sliceSpeed;
    public float moveSpeed;

    private FoodController foodController;
    private int foodValue;

    private bool hasSliced;
    private bool hasPressed;

    public AudioClip miss;
    public AudioClip chop;
    AudioSource audioSource;
    
    //Hand
    public GameObject rightHand;

    //public Sprite handHeld;
    //public Sprite handChopping;
    //public Sprite handChopped;

    //Eyebrows
    public GameObject eyebrows;

    public Sprite normalEyebrows;
    public Sprite angryEyebrows;

    //Eyes
    public GameObject eyes;

    public Sprite normalEyes;
    public Sprite happyEyes;

    private Rigidbody playerRB;

    private GameObject food;

    private Vector3 originalPos;

    public int failNumber = 0;

    public float noteSpeed = 1f;

    public RaycastHit hit;
    public Transform target;

    private void Awake()
    {
        playerRB = GetComponent<Rigidbody>();
        food = GameObject.FindGameObjectWithTag("Food");
        target = GameObject.FindGameObjectWithTag("Target").GetComponent<Transform>();

        foodController = GameObject.FindGameObjectWithTag("Food").GetComponent<FoodController>();
        foodValue = foodController.totalScore;

        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    // Start is called before the first frame update
    void Start()
    {
        //sliceSpeed = 200f;
        //moveSpeed = 50f;
        hasSliced = false;
        hasPressed = false;
        originalPos = transform.position;
        audioSource = GetComponent<AudioSource>();
        rightHand = GameObject.FindGameObjectWithTag("Right Hand");
    }

    // Update is called once per frame
    void Update()
    {
        Slice();
        //StopAtOriginalPosition();

        if (failNumber == 3)
        {
            SceneManager.LoadScene(0);
        }
    }

    public void Slice()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !hasPressed)
        {
            if (Physics.Linecast(transform.position, target.position))
            {
                print("hit");
                //ReturnToPosition();
                failNumber = 0;
                noteSpeed += 0.1f;
                audioSource.PlayOneShot(chop);
                audioSource.pitch += 0.1f;
                food = GameObject.FindGameObjectWithTag("Food");
                food.GetComponent<Renderer>().material.color = new Color(0f, 1f, 0f);
                //Debug.Log("You hit the mark!!");
                foodValue = foodController.totalScore;
                gameManager.scoreText.text = "Score: " + foodController.AddScore(foodValue);

                if(eyebrows.GetComponent<SpriteRenderer>().sprite == angryEyebrows)
                {
                    eyebrows.GetComponent<SpriteRenderer>().sprite = normalEyebrows;
                }
                else
                {
                    eyes.GetComponent<SpriteRenderer>().sprite = happyEyes;
                }
            }
            else
            {
                print("miss");
                audioSource.PlayOneShot(miss);
                audioSource.pitch -= 0.1f;
                //ReturnToPosition();
                failNumber++;
                noteSpeed -= 0.1f;
                foodValue = foodController.totalScore;
                gameManager.scoreText.text = "Score: " + foodController.SubScore(foodValue);

                if(eyes.GetComponent<SpriteRenderer>().sprite = happyEyes)
                {
                    eyes.GetComponent<SpriteRenderer>().sprite = normalEyes;
                }
                else
                {
                    eyebrows.GetComponent<SpriteRenderer>().sprite = angryEyebrows;
                }
            }

            /*
                        RaycastHit hit = Physics.Raycast(transform.position, -Vector2.up, 500f);
                        if (hit.collider.tag == "Food")
                        {
                            ReturnToPosition();
                            failNumber = 0;
                            noteSpeed += 0.1f;
                            audioSource.PlayOneShot(chop);
                            audioSource.pitch += 0.1f;
                            food = GameObject.FindGameObjectWithTag("Food");
                            food.GetComponent<Renderer>().material.color = new Color(0f, 1f, 0f);
                            //Debug.Log("You hit the mark!!");
                            foodValue = foodController.totalScore;
                            gameManager.scoreText.text = "Score: " + foodController.AddScore(foodValue);
                        }
                        if (hit.collider.tag == null)
                        {
                            audioSource.PlayOneShot(miss);
                            audioSource.pitch -= 0.1f;
                            ReturnToPosition();
                            failNumber++;
                            noteSpeed -= 0.1f;
                            foodValue = foodController.totalScore;
                            gameManager.scoreText.text = "Score: " + foodController.SubScore(foodValue);
                        }
                        playerRB.AddForce(Vector3.down * sliceSpeed);
                        //transform.Translate(Vector3.down * sliceSpeed * Time.deltaTime);
                        hasSliced = true;
                        hasPressed = true;
                    }
            */

        }

        /*
            public void ReturnToPosition()
            {
                if (hasSliced)
                {
                    playerRB.AddForce(originalPos * moveSpeed);
                    //playerRB.MovePosition(originalPos);
                    //playerRB.transform.Translate(originalPos);
                    playerRB.velocity = Vector3.zero;
                    hasPressed = false;
                }
            }
        */

        /*
            public void StopAtOriginalPosition()
            {
                if (playerRB.position.y >= 5)
                {
                    playerRB.velocity = Vector3.zero;
                    //Debug.Log("Has made it to original position");
                }
            }
        */

        /*
        private void OnCollisionEnter(Collision c)
        {
            if (c.gameObject.CompareTag("Table"))
            {
                audioSource.PlayOneShot(miss);
                audioSource.pitch -= 0.1f;
                ReturnToPosition();
                failNumber ++;
                noteSpeed -= 0.1f;
                foodValue = foodController.totalScore;
                gameManager.scoreText.text = "Score: " + foodController.SubScore(foodValue);
            }
        }
        */

        /*
            private void OnTriggerEnter(Collider c)
            {
                if(c.gameObject.CompareTag("Food"))
                {
                    ReturnToPosition();
                    failNumber = 0;
                    noteSpeed += 0.1f;
                    audioSource.PlayOneShot(hit);
                    audioSource.pitch += 0.1f;
                    food = GameObject.FindGameObjectWithTag("Food");
                    food.GetComponent<Renderer>().material.color = new Color(0f, 1f, 0f);
                    //Debug.Log("You hit the mark!!");
                    foodValue = foodController.totalScore;
                    gameManager.scoreText.text = "Score: " + foodController.AddScore(foodValue);
                }
            }
        */
    }
}