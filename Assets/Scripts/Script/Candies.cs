using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candies : MonoBehaviour
{
public static Candies instance;
BoxCollider2D CandyCollider ;

void Start(){
    instance = this;

    CandyCollider = GetComponent<BoxCollider2D>();
}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            GameManager.instance.UpdateScore();
            Destroy(gameObject);
        }
    }
}
