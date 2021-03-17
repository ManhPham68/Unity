using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Started : MonoBehaviour
{
    
    public Rigidbody2D r;
    public Animator a;
    public bool grounded = true,faceright=true,doublejump=false;
    public Gamemaster gm;
    public float speed = 60f, maxspeed = 5, jumPow = 200f;
    // Start is called before the first frame update
    void Start()
    {
        r = gameObject.GetComponent<Rigidbody2D>();
        a = gameObject.GetComponent<Animator>();
        gm = GameObject.FindGameObjectWithTag("Gamemaster").GetComponent<Gamemaster>();
        
    }

    // Update is called once per frame
    void Update()
    {
        a.SetBool("Grounded", grounded);
        a.SetFloat("Speed", Mathf.Abs(r.velocity.x));
        if(Input.GetKeyDown(KeyCode.Space))
        {
            doublejump = true;
            if (grounded) r.AddForce((Vector2.up) * jumPow);   
        }
        else
        {
            if(doublejump)
            {
                doublejump = false;
                r.velocity = new Vector2(r.velocity.x, 0);
                r.AddForce((Vector2.up) * jumPow*0.5f);
            }
        }
        
    }
     void FixedUpdate()
    {
        float h = Input.GetAxis("Game");
        r.AddForce((Vector2.right) * speed * h);
        if (r.velocity.x > maxspeed)
            r.velocity = new Vector2(maxspeed, r.velocity.y);
        if (r.velocity.x < -maxspeed)
            r.velocity = new Vector2(-maxspeed, r.velocity.y);
        
        if(h>0 && !faceright)
        {
            Flip();
        }
        if(h<0 && faceright)
        {
            Flip();
        }
        if(grounded)
        {
            r.velocity = new Vector2(r.velocity.x * 0.7f, r.velocity.y);
        }
    }
    public void Flip()
    {
        faceright = !faceright;
        Vector3 Scale;
        Scale = transform.localScale;
        Scale.x *= -1;
        transform.localScale = Scale;
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Coins"))
        {
            Destroy(col.gameObject);
            gm.points += 1;

        }
        
    }
}
