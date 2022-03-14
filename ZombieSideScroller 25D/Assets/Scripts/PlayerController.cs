using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    //Variables para el movimiento
    Animator playerAnim;
    Rigidbody rb2d;
    [SerializeField] float runSpeed;
    [SerializeField] float walkSpeed;
    bool facingRight;

    //Para el salto
    bool grounded = false;
    Collider[] groundCollisions;
    float groundCheckRadius = 0.2f;
    LayerMask groundLayer;
    [SerializeField] Transform groundCheck;
    [SerializeField] float jumpHeight; 

    // Start is called before the first frame update
    void Awake()
    {
        playerAnim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody>();
        groundLayer = LayerMask.GetMask("ground");
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
        //Animaciones y salto
        if(grounded && Input.GetAxis("Jump") > 0){
            grounded = false;
            playerAnim.SetBool("grounded", grounded);
            rb2d.AddForce(new Vector3(0, jumpHeight, 0));
        }

        groundCollisions = Physics.OverlapSphere(groundCheck.position, groundCheckRadius, groundLayer);
        if(groundCollisions.Length > 0) grounded = true;
        else grounded = false;

        playerAnim.SetBool("grounded", grounded);
        playerAnim.SetFloat("verticalSpeed", rb2d.velocity.y);



        //Movimiento
        float move = Input.GetAxis("Horizontal");
        playerAnim.SetFloat("speed", Mathf.Abs(move));
        float sneaking = Input.GetAxisRaw("Fire3");
        playerAnim.SetFloat("sneaking", sneaking);

        if(sneaking > 0 && grounded){
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

    public float GetFacing(){
        if(facingRight)return 1;
        else return -1;
    }
}
