using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CharMovement : MonoBehaviour
{
    public Rigidbody2D feet;

    public ContactFilter2D ContactFilter;

    public List<CompositeCollider2D> collisionListCanJump;

    public float jumpImpulse, speedX;
    public float maxSpeedY = 0, maxSpeedX = 0;
    public float speedMultiplier = 10;

    //private bool ableToJump = true;

    //private bool isGrounded => body.IsTouching(GetComponent("Background").GetComponent<Collider2D>());

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("a"))
        {
            Move(-1, 0);
        }
        if (Input.GetKey("d"))
        {
            Move(1, 0);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            collisionListCanJump.ForEach(collider =>
            {
                if (feet.IsTouching(collider))
                {
                    Jump();
                }
            });
        }
    }

    private void Move(int vecX, int vecY)
    {
        if (feet.velocity.x >= maxSpeedX || feet.velocity.x <= -maxSpeedX) vecX = 0;
        if (feet.velocity.y >= maxSpeedY || feet.velocity.y <= -maxSpeedY) vecY = 0;

        Vector2 vec = new Vector2();
        vec.x = vecX * speedMultiplier * Time.deltaTime * speedX;
        vec.y = vecY * speedMultiplier * Time.deltaTime * jumpImpulse;
        feet.AddForce(vec);
    }

    private void Jump()
    { 
        Vector2 vec = new Vector2();
        vec.y = jumpImpulse;
        feet.velocity = vec;
    }

}
