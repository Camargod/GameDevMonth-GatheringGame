using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;


public class CharMovement : MonoBehaviour
{

    public static CharMovement instance;
    public Rigidbody2D feet;

    public ContactFilter2D ContactFilter;

    public List<CompositeCollider2D> collisionListCanJump;
    public SpriteRenderer sprite;

    public float jumpImpulse, speedX;
    public float maxSpeedY = 0, maxSpeedX = 0;
    public float speedMultiplier = 10;

    public string nextSceneDebug = "";

    //private bool ableToJump = true;

    //private bool isGrounded => body.IsTouching(GetComponent("Background").GetComponent<Collider2D>());

    // Start is called before the first frame update
    void Start()
    {
       instance = this;
       sprite = GetComponent<SpriteRenderer>();
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
        if (Input.GetKey(KeyCode.Backslash))
        {
            SceneManager.LoadScene(nextSceneDebug);
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

     public IEnumerator DamagePlayer()
    {
        sprite.color = new Color(1f, 1f, 1f, 1f);
        yield return new WaitForSeconds(0.2f);
        sprite.color = new Color(1f, 0f, 0f, 1f);

        for (int i = 0; i < 7; i++)
        {
            sprite.enabled = false;
            yield return new WaitForSeconds(0.15f);
            sprite.enabled = true;
            yield return new WaitForSeconds(0.15f);
        }
         CharacterScript.bc.enabled = true;
    }
   
}
