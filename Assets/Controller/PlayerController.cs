using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;
    public float jumpForce = 7.5f;
    public Transform groundCheck;
    public Transform portalCheck;
    public Transform playerTransform;
    public float checkRadius = 0.1f;
    public SpriteRenderer playerSprite;
    public LayerMask groundLayer;
    public LayerMask portalLayer;
    public string jumpInput;
    public string horizontalAxis;
    public SpriteRenderer endingScreen;

    private Rigidbody2D rb;
    private bool isGrounded;
    private bool PortalBool;
    private bool isPortal;

    void OnBecameInvisible()
    {
        endingScreen.enabled = true;
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        PortalBool = true;
    }

    void Update()
    {
        isPortal = Physics2D.OverlapCircle(portalCheck.position, 1f, portalLayer);
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer);

        if (isPortal && PortalBool && horizontalAxis == "Horizontal_P2")
        {
            PortalBool = false;
            rb.gravityScale = rb.gravityScale * -1;
            playerTransform.eulerAngles = new Vector3(
                playerTransform.transform.eulerAngles.x,
                playerTransform.transform.eulerAngles.y,
                playerTransform.transform.eulerAngles.z + 180
            );

        }

        if (Input.GetButtonDown(jumpInput) && isGrounded )
        {
            if (jumpInput == "Jump_P2" && PortalBool)
                rb.velocity = new Vector2(rb.velocity.x, -jumpForce);
            else
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
        rb.velocity = new Vector2(5f * Input.GetAxis(horizontalAxis), rb.velocity.y);


        if (Input.GetAxis(horizontalAxis) < 0)
            playerSprite.flipX = true;
        else
            playerSprite.flipX = false;
        if (horizontalAxis == "Horizontal_P2" && PortalBool)
            playerSprite.flipX = !playerSprite.flipX;
    }
}
