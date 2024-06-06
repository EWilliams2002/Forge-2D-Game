using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
   Rigidbody2D body;

   float horizontal;
   float vertical;

   public float speed;
    
    // Start is called before the first frame update
void Start () 
{
   body = GetComponent<Rigidbody2D>(); 
}

void Update ()
{
   horizontal = Input.GetAxisRaw("Horizontal");
   vertical = Input.GetAxisRaw("Vertical"); 
}

private void FixedUpdate()
{  
   body.velocity = new Vector2(horizontal * speed, vertical * speed);
}
}
