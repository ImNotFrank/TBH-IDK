using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveEnemy : MonoBehaviour
{
    private BoxCollider2D coll;
    private Rigidbody2D rb;
    private float dirX = 1f;
    [SerializeField] float moveSpeed;
    [SerializeField] private LayerMask ground;
    // Start is called before the first frame update
    private void Start()
    {
        coll = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
    }

    public void edge(float dir)
    {
        dirX = dir;
    }
    private bool isGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, ground);
    }
}
