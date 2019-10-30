
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

    public GameObject rightHand;
    public Sprite handHeld;
    public Sprite handChopping;
    public Sprite handChopped;

    private Rigidbody playerRB;

    private GameObject food;

    private Vector3 originalPos;

    public int failNumber = 15;

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

    }

    // Update is called once per frame
    void Update()
    {

    }
}