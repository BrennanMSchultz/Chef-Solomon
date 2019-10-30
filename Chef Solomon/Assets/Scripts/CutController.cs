using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutController : MonoBehaviour
{
    public bool In = false;
    private GameManager gameManager;

    private FoodController foodController;
    private int foodValue;

    private bool hasSliced;
    private bool hasPressed;

    public AudioClip miss;
    public AudioClip chop;
    AudioSource audioSource;

    public GameObject rightHand;

    public Sprite handHeld;
    public Sprite handChopping;
    public Sprite handChopped;

    private GameObject food;

    public int failNumber = 0;

    public float noteSpeed = 1f;

    private void Awake()
    {
        food = GameObject.FindGameObjectWithTag("Food");
        foodController = GameObject.FindGameObjectWithTag("Food").GetComponent<FoodController>();
        foodValue = foodController.totalScore;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Cut();
    }

    public void Cut()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (In == true)
            {
                failNumber +=2;
                noteSpeed += 0.1f;
                audioSource.PlayOneShot(chop);
                audioSource.pitch += 0.1f;
                food = GameObject.FindGameObjectWithTag("Food");
                food.GetComponent<Renderer>().material.color = new Color(0f, 1f, 0f);
                foodValue = foodController.totalScore;
                gameManager.scoreText.text = "Score: " + foodController.AddScore(foodValue);
            }
            else
            {
                audioSource.PlayOneShot(miss);
                audioSource.pitch -= 0.1f;
                failNumber--;
                noteSpeed -= 0.1f;
                foodValue = foodController.totalScore;
                gameManager.scoreText.text = "Score: " + foodController.SubScore(foodValue);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Food"))
        {
            print("in");
            In = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Food"))
        {
            print("out");
            In = false;
        }
    }
}
