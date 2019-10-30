using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutController : MonoBehaviour
{
    public bool In = false;
    public bool In2 = false;
    private GameManager gameManager;

    private FoodController foodController;
    private int foodValue;

    public AudioClip miss;
    public AudioClip chop;
    AudioSource audioSource;

    public GameObject rightHand;
    public GameObject leftHand;

    private GameObject food;
    private GameObject food2;

    public int failNumber = 0;

    public float noteSpeed = 1f;

    private void Awake()
    {
        food = GameObject.FindGameObjectWithTag("Food");
        foodController = GameObject.FindGameObjectWithTag("Food").GetComponent<FoodController>();
        food2 = GameObject.FindGameObjectWithTag("Food 2");
        foodController = GameObject.FindGameObjectWithTag("Food 2").GetComponent<FoodController>();
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
        if (failNumber <= 0)
        {
            SceneManager.LoadScene(0);
        }
        Cut();
        Cut2();
    }

    public void Cut()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (In == true)
            {
                failNumber ++;
                noteSpeed += 0.1f;
                audioSource.PlayOneShot(chop);
                audioSource.pitch += 0.05f;
                food = GameObject.FindGameObjectWithTag("Food");
                food.GetComponent<Renderer>().material.color = new Color(0f, 1f, 0f);
                foodValue = foodController.totalScore;
                gameManager.scoreText.text = "Score: " + foodController.AddScore(foodValue);
            }
            else
            {
                audioSource.PlayOneShot(miss);
                audioSource.pitch -= 0.05f;
                failNumber-=2;
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
        if (other.gameObject.CompareTag("Food 2"))
        {
            print("in2");
            In2 = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Food"))
        {
            print("out");
            In = false;
        }
        if (other.gameObject.CompareTag("Food 2"))
        {
            print("out2");
            In2 = false;
        }
    }

    public void Cut2()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            if (In2 == true)
            {
                failNumber ++;
                noteSpeed += 0.1f;
                audioSource.PlayOneShot(chop);
                audioSource.pitch += 0.05f;
                food2 = GameObject.FindGameObjectWithTag("Food 2");
                food2.GetComponent<Renderer>().material.color = new Color(0f, 1f, 0f);
                foodValue = foodController.totalScore;
                gameManager.scoreText.text = "Score: " + foodController.AddScore(foodValue);
            }
            else
            {
                audioSource.PlayOneShot(miss);
                audioSource.pitch -= 0.05f;
                failNumber-=2;
                noteSpeed -= 0.1f;
                foodValue = foodController.totalScore;
                gameManager.scoreText.text = "Score: " + foodController.SubScore(foodValue);
            }
        }
    }
}
