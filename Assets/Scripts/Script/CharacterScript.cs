using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterScript : MonoBehaviour
{
        public static BoxCollider2D bc;

        

    // Start is called before the first frame update
   private void Start()
    {
          bc = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
        /// Handling different collisions
        /// Char collisions
    private void OnTriggerEnter2D(Collider2D collision)
    {
       if(collision.gameObject.tag == "Enemy")
       {
            GameManager.instance.LessLife();
            bc.enabled = false;
            
            StartCoroutine(CharMovement.instance.DamagePlayer());
       }

    }

}
