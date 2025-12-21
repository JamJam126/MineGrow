using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 4f; 

    private Rigidbody2D rb;
    private Vector2 movement;

    private Animator anim;
    private SpriteRenderer sr;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        
        if (x != 0 && y != 0) x = 0;

        movement = new Vector2(x, y);

        // Debug.Log(movement.sqrMagnitude > 0.01f);  
        // Debug.Log(movement.x);      
        anim.SetFloat("MoveX", movement.x);
        anim.SetFloat("MoveY", movement.y);
        anim.SetFloat("MoveXAbs", Mathf.Abs(movement.x));
        anim.SetBool("IsMoving", movement.sqrMagnitude > 0.01f);

        if (movement.x < 0) sr.flipX = true;
        else if (movement.x > 0) sr.flipX = false;
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
