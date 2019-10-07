using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private float sliceSpeed;

    private bool hasSliced;
    private bool hasPressed;

    private Rigidbody playerRB;

    private Vector3 originalPos;

    private void Awake()
    {
        playerRB = GetComponent<Rigidbody>();
    }
    // Start is called before the first frame update
    void Start()
    {
        sliceSpeed = 200f;
        hasSliced = false;
        hasPressed = false;
        originalPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Slice();
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
            transform.Translate(originalPos);
            hasPressed = false;
        }
    }

    private void OnCollisionEnter(Collision c)
    {
        if (c.gameObject.CompareTag("Table"))
        {
            ReturnToPosition();
        }
    }


}