
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float sliceSpeed;
    public float moveSpeed;

    private bool hasSliced;
    private bool hasPressed;

    public AudioClip miss;
    public AudioClip hit;
    AudioSource audioSource;

    private Rigidbody playerRB;

    private GameObject food;

    private Vector3 originalPos;

    private void Awake()
    {
        playerRB = GetComponent<Rigidbody>();
        food = GameObject.FindGameObjectWithTag("Food");
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
    }

    // Update is called once per frame
    void Update()
    {
        Slice();
        StopAtOriginalPosition();
    }

    public void Slice()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !hasPressed)
        {
            playerRB.AddForce(Vector3.down * sliceSpeed);
            //transform.Translate(Vector3.down * sliceSpeed * Time.deltaTime);
            hasSliced = true;
            hasPressed = true;
        }
    }
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

    public void StopAtOriginalPosition()
    {
        if (playerRB.position.y >= 5)
        {
            playerRB.velocity = Vector3.zero;
            Debug.Log("Has made it to original position");
        }
    }

    private void OnCollisionEnter(Collision c)
    {
        if (c.gameObject.CompareTag("Table"))
        {
            audioSource.PlayOneShot(miss);
            //tempo lowers
            ReturnToPosition();
        }
    }

    private void OnTriggerEnter(Collider c)
    {
        if(c.gameObject.CompareTag("Food"))
        {
            ReturnToPosition();
            audioSource.PlayOneShot(hit);
            //tempo increases
            food.GetComponent<Renderer>().material.color = new Color(0f, 1f, 0f);
            Debug.Log("You hit the mark!!");
        }
    }
}