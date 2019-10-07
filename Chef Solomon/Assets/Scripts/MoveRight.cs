using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRight : MonoBehaviour
{

    private float speed = 10f;
    private bool outOfBounds;
    Vector3 xMovement = (Vector3.right);

    // Start is called before the first frame update
    void Start()
    {
        outOfBounds = false;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        OutOfBounds();
    }

    public void Movement()
    {
        transform.Translate(xMovement * speed * Time.deltaTime);
    }

    public void OutOfBounds()
    {
        if(!outOfBounds && transform.position.x > 10)
        {
            Destroy(gameObject);
        }
    }
}
