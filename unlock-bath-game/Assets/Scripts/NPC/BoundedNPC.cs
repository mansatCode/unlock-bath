using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundedNPC : Interactable
{

    private Vector3 directionVector;
    private Transform myTransform;
    public float speed;
    private Rigidbody2D myRigidBody;
    private Animator anim;
    public Collider2D bounds;
    private bool canMove = true;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        myTransform = GetComponent<Transform>();
        myRigidBody = GetComponent<Rigidbody2D>();
        ChangeDirection();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isInRange) // Check if player is around to stop NPC
        {
            Move();
        }
    }

    private void Move()
    {
        Vector3 temp = myTransform.position + directionVector * speed * Time.deltaTime;

        if (bounds.bounds.Contains(temp))
        {
            myRigidBody.MovePosition(temp);
        }
        else
        {
            ChangeDirection();
        }

    }

    void ChangeDirection()
    {
        int direction = Random.Range(0, 4);
        switch (direction)
        {
            case 0:
                // Right
                directionVector = Vector3.right;
                break;
            case 1:
                // Up
                directionVector = Vector3.up;
                break;
            case 2:
                // Left
                directionVector = Vector3.left;
                break;
            case 3:
                // Down
                directionVector = Vector3.down;
                break;
            default:
                break;
        }
        UpdateAnimation();
    }

    void UpdateAnimation()
    {
        anim.SetFloat("MoveX", directionVector.x);
        anim.SetFloat("MoveY", directionVector.y);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Vector3 tempDir = directionVector;
        ChangeDirection();
        int loops = 0;
        while (tempDir == directionVector)
        {
            loops++;
            ChangeDirection();
        }

    }
}
