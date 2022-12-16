using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public float upForce;
    private bool isDead = false;

    private Animator anim;
    private Rigidbody2D rb2d;


    // Start is called before the first frame update
    void Start()
    {
        //Get reference to the Animator component attached to this GameObject.
        anim = GetComponent<Animator> ();

        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead == false)
        {
            //Look for input to trigger a "flap".
            if (Input.GetMouseButtonDown(0))
            {
                //...tell the animator about it and then...
                anim.SetTrigger("Flap");
                //...zero out the birds current y velocity before...
                rb2d.velocity = Vector2.zero;
                //... new Vecter2(rb2d.velocity.x,0);
                //..givng the bird some upward force.
                rb2d.AddForce(new Vector2(0, upForce));
            }
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        // zero out the bird velocity
        rb2d.velocity = Vector2.zero;
        // If the bird collides with something set it to dead...
        isDead = true;
        //...and tell the animaotr abouyt it...
        anim.SetTrigger("Die");
        //...and tell the game control about it.
        GameControl.instance.BirdDied();
    }
}
