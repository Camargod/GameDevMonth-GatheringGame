using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CharMovement : MonoBehaviour
{
    public Rigidbody2D body;

    public ContactFilter2D ContactFilter;

    public Collider2D background;

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
            if (body.IsTouching(background))
            {
                Jump();
            }
        }
    }

    private void Move(int vecX, int vecY)
    {
        Vector2 vec = new Vector2();
        vec.x = vecX * 10 * Time.deltaTime * 50;
        vec.y = vecY * 10 * Time.deltaTime * 50;
        body.AddForce(vec);
    }

    private void Jump()
    { 
        Vector2 vec = new Vector2();
        vec.y = 14;
        body.AddForce(vec);
    }

}
