using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    
    // animator 참조
    private Animator anim;
    private Transform tr;

    public float speed = 7f;

    void Start()
    {
        anim = GetComponent<Animator>();
        tr = GetComponent<Transform>();
    }

    public void Move(float x, float y)
    {
        Vector2 movement = new Vector2(x, y).normalized;
        tr.Translate(movement * speed * Time.deltaTime);

        anim.SetFloat("Direction_X", x);
        anim.SetFloat("Direction_Y", y);

    }

}
