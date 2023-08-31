using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float jumpVelocity = 1f;
    
    private Rigidbody2D rb;
    [HideInInspector] public bool isAlive = true;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Jump()
    {
        if (!isAlive) { return; }
        Vector2 push = new Vector2(0, jumpVelocity);
        rb.velocity = push;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Hazard"))
        {
            isAlive = false;
        }
    }
}
