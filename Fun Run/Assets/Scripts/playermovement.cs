using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playermovement : MonoBehaviour
{
    public Transform respawnLocation;
    public float speed = 6.0F;
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;
    public GameObject brokenSkin;
    private Vector3 moveDirection = Vector3.zero;
    public Animator anim;
    bool alreadyFalling;
    private int dropTimes;
    public Text drops;
    CharacterController controller;
    public bool canJump;
    public bool onGround;
    public float raycastSize = 1;
    int layer_mask;

    bool triggerGround;
    bool triggerFall;
    public void ReturntoPoint()
    {
        GameObject cubes = Instantiate(brokenSkin, transform.position, transform.rotation);
        Destroy(cubes, 3f);
        transform.position = respawnLocation.position;
        dropTimes++;
        if (drops)
            drops.text = "Times Dropped: " + dropTimes.ToString();
        anim.SetFloat("speed", 0);

        moveDirection = Vector3.zero;
    }
    private void Start()
    {
        layer_mask = LayerMask.GetMask("Base");
        controller = GetComponent<CharacterController>();
        if (drops)
            drops.text = "Times Dropped: " + dropTimes.ToString();
    }
    void FixedUpdate()
    {
        Vector3 fwd = transform.TransformDirection(Vector3.down);
        bool ray2 = Physics.Raycast(transform.position + new Vector3(0, 0, .5f), fwd, raycastSize, layer_mask);
        bool ray3 = Physics.Raycast(transform.position + new Vector3(0, 0, .25f), fwd, raycastSize, layer_mask);
        bool ray4 = Physics.Raycast(transform.position + new Vector3(0, 0, -.5f), fwd, raycastSize, layer_mask);
        bool ray5 = Physics.Raycast(transform.position + new Vector3(0, 0, -.25f), fwd, raycastSize, layer_mask);

        Debug.DrawRay(transform.position, fwd * raycastSize, Color.red);
        Debug.DrawRay(transform.position + new Vector3(0, 0, .5f),  fwd* raycastSize, Color.red);
        Debug.DrawRay(transform.position + new Vector3(0, 0, .25f), fwd* raycastSize, Color.red);
        Debug.DrawRay(transform.position + new Vector3(0, 0, -.5f), fwd* raycastSize, Color.red);
        Debug.DrawRay(transform.position + new Vector3(0, 0, -.25f), fwd* raycastSize, Color.red);

        onGround = Physics.Raycast(transform.position, fwd, raycastSize, layer_mask);
        if (ray2 || ray3 || ray4 || ray5)
            onGround = true;
        if (!onGround)
        {
            bool canJump1 = Physics.Raycast(transform.position, fwd, 1.5f, layer_mask);
            bool canJump2 = Physics.Raycast(transform.position + new Vector3(0, 0, .5f), fwd, 1.5f, layer_mask);
            bool canJump3 = Physics.Raycast(transform.position + new Vector3(0, 0, .25f), fwd, 1.5f, layer_mask);
            bool canJump4 = Physics.Raycast(transform.position + new Vector3(0, 0, -.5f), fwd, 1.5f, layer_mask);
            bool canJump5 = Physics.Raycast(transform.position + new Vector3(0, 0, -.25f), fwd, 1.5f, layer_mask);

            Debug.DrawRay(transform.position, fwd * 1.5f, Color.blue);
            Debug.DrawRay(transform.position + new Vector3(0, 0, .5f), fwd * 1.5f, Color.blue);
            Debug.DrawRay(transform.position + new Vector3(0, 0, .25f), fwd * 1.5f, Color.blue);
            Debug.DrawRay(transform.position + new Vector3(0, 0, -.5f), fwd * 1.5f, Color.blue);
            Debug.DrawRay(transform.position + new Vector3(0, 0, -.25f), fwd * 1.5f, Color.blue);
            if (canJump1 || canJump2 || canJump3 || canJump4 || canJump5)
            {
                if (!triggerGround)
                {
                    anim.SetTrigger("Ground");
                    anim.ResetTrigger("Falling");
                    triggerGround = true;
                    triggerFall = false;
                }
                canJump = true;
            }
            else {
                canJump = false;
                if (!triggerFall)
                {
                    anim.SetTrigger("Falling");
                    anim.ResetTrigger("Ground");
                    triggerGround = false;
                    triggerFall = true;
                }

            }
        }
        else
        {
            if (!triggerGround)
            {
                anim.SetTrigger("Ground");
                anim.ResetTrigger("Falling");
                triggerGround = true;
                triggerFall = false;
            }
            canJump = true;
        }
        
    }
    void Update()
    {

        if (transform.position.y < -5)
        {
            ReturntoPoint();
        }

        float h = Input.GetAxis("Horizontal");
        float old = moveDirection.y;

        moveDirection = new Vector3(0, 0, h);

        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection *= speed;
        if (canJump && Input.GetButton("Jump"))
        {
            moveDirection.y = jumpSpeed;
            anim.SetTrigger("Jump");
        }

        if (onGround)
        {
            alreadyFalling = false;

        }
        else
        {

            moveDirection.y = old;
        }



        anim.SetFloat("speed", Mathf.Abs(h * speed));


        if (!onGround && !alreadyFalling)
        {
            alreadyFalling = true;
            anim.SetTrigger("Falling");
        }

        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
    }
}
