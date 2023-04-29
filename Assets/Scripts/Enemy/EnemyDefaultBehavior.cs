using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDefaultBehavior : MonoBehaviour
{

    public float enemySpeed = 10;

    Rigidbody2D body;
    BoxCollider2D Collider;

    // Start is called before the first frame update
    void Start()
    {
        this.body = GetComponent<Rigidbody2D>();
        this.Collider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        body.AddForce(new Vector2(forceX(), 0));
    }

    float forceX()
    {
        float vectorX = -1f;

        if (IsFacingRight()){vectorX = 1f;}

        return enemySpeed * vectorX * Time.deltaTime;
    }

    private bool IsFacingRight()
    {
        return transform.localScale.x > Mathf.Epsilon;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        transform.localScale = new Vector2(-(Mathf.Sign(body.velocity.x)), transform.localScale.y);
    }   
}
