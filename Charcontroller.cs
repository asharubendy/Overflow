using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charcontroller : MonoBehaviour
{
  
  public float moveSpeed = 5f;
  public Rigidbody2D rigid;
  
  Vector2 movement; 

    void Update()
    {
       movement.x = Input.GetAxisRaw("Horizontal");
       movement.y = Input.GetAxisRaw("Vertical");
    }
    void FixedUpdate()
    {
        rigid.MovePosition(rigid.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
