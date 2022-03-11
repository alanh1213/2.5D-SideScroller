using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    Animator playerAnim;
    Rigidbody rb2d;
    [SerializeField] float runSpeed;
    [SerializeField] float walkSpeed;
    bool facingRight;


    // Start is called before the first frame update
    void Awake()
    {
        playerAnim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody>();
    }

    private void Start() {
        facingRight = true;
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        float move = Input.GetAxis("Horizontal");
        playerAnim.SetFloat("speed", Mathf.Abs(move));
        float sneaking = Input.GetAxisRaw("Fire3");
        playerAnim.SetFloat("sneaking", sneaking);

        if(sneaking > 0){
            rb2d.velocity = new Vector3(move * walkSpeed, rb2d.velocity.y, 0);
        }else{
            rb2d.velocity = new Vector3(move * runSpeed, rb2d.velocity.y, 0);
        }
        

        if(move > 0 && !facingRight)Flip();
        else if(move < 0 && facingRight) Flip();
    }

    void Flip(){
        facingRight = !facingRight;
        transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z * -1);
    }
}
