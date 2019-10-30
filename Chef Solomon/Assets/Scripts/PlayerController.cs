
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

    //private bool cleaver1Pressed;
    //private bool cleaver2Pressed;

    public AudioClip miss;
    public AudioClip hit;
    AudioSource audioSource;

    private Rigidbody playerRB;

    private GameObject food;

    private Vector3 firstCleaverOriginalPos;
    private Vector3 secondCleaverOriginalPos;

    public int totalFails;

    public float noteSpeed = 1f;

    private void Awake()
    {
        playerRB = GetComponent<Rigidbody>();
        food = GameObject.FindGameObjectWithTag("Food");

        foodController = GameObject.FindGameObjectWithTag("Food").GetComponent<FoodController>();
        foodValue = foodController.totalScore;

        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    // Start is called before the first frame update
    void Start()
    {
        hasSliced = false;
        hasPressed = false;
        //cleaver1Pressed = false;
        //cleaver2Pressed = false;
        firstCleaverOriginalPos = GameObject.Find("Cleaver").transform.position;
        secondCleaverOriginalPos = GameObject.Find("Second Cleaver").transform.position;
        Debug.Log("This is the second cleaver's original position: " + secondCleaverOriginalPos);
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //LeftSlice();
        //RightSlice();
        Slice();
        StopAtOriginalPosition();

        //if (failNumber == 3)
        //{
        //    SceneManager.LoadScene(0);
        //}
    }

    public void Slice()
    {
        if (Input.GetKeyDown(KeyCode.F) && !hasPressed && this.CompareTag("Cleaver")) //!hasPressed
        {
            playerRB.AddForce(Vector3.down * sliceSpeed);
            //transform.Translate(Vector3.down * sliceSpeed * Time.deltaTime);
            hasSliced = true;
            hasPressed = true;
           // cleaver1Pressed = true;
        }
        if (Input.GetKeyDown(KeyCode.J) && !hasPressed && this.CompareTag("Cleaver2")) //!hasPressed
        {
            playerRB.AddForce(Vector3.down * sliceSpeed);
            //transform.Translate(Vector3.down * sliceSpeed * Time.deltaTime);
            hasSliced = true;
            //hasPressed = true;
            hasPressed = true;
        }
    }

    //public void LeftSlice()
    //{
    //    if (Input.GetKeyDown(KeyCode.F) && !cleaver1Pressed && this.CompareTag("Cleaver")) //!hasPressed
    //    {
    //        playerRB.AddForce(Vector3.down * sliceSpeed);
    //        //transform.Translate(Vector3.down * sliceSpeed * Time.deltaTime);
    //        hasSliced = true;
    //        //hasPressed = true;
    //        cleaver1Pressed = true;
    //    }
    //}
    //public void RightSlice()
    //{
    //    if (Input.GetKeyDown(KeyCode.J) && !cleaver2Pressed && this.CompareTag("Cleaver2")) //!hasPressed
    //    {
    //        playerRB.AddForce(Vector3.down * sliceSpeed);
    //        //transform.Translate(Vector3.down * sliceSpeed * Time.deltaTime);
    //        hasSliced = true;
    //        //hasPressed = true;
    //        cleaver2Pressed = true;
    //    }
    //}
    public void ReturnToPosition()
    {
        if (hasSliced)
        {
            //if (cleaver1Pressed)
            //{
            //    playerRB.AddForce(Vector3.up * Mathf.Pow(moveSpeed, 2f));
            //    cleaver1Pressed = false;
            //}
            //else if (cleaver2Pressed)
            //{
            //    playerRB.AddForce(Vector3.up * Mathf.Pow(moveSpeed, 2f));
            //    cleaver2Pressed = false;
            //}

            playerRB.AddForce(Vector3.up * Mathf.Pow(moveSpeed, 2f));
            hasPressed = false;
            //playerRB.MovePosition(originalPos);
            //playerRB.transform.Translate(originalPos);
            //playerRB.velocity = Vector3.zero;
        }
    }

    public void StopAtOriginalPosition()
    {
        if (playerRB.position.y >= 5)
        {
            playerRB.velocity = Vector3.zero;
            //Debug.Log("Has made it to original position");
        }
    }

    private void OnCollisionEnter(Collision c)
    {
        if (c.gameObject.CompareTag("Table"))
        {
            audioSource.PlayOneShot(miss);
            audioSource.pitch -= 0.1f;
            ReturnToPosition();
            totalFails++;
            noteSpeed -= 0.1f;
            foodValue = foodController.totalScore;
            gameManager.scoreText.text = "Score: " + foodController.SubScore(foodValue);
        }
    }

    private void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.CompareTag("Food"))
        {
            ReturnToPosition();
            totalFails = 0;
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
}