using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float speed;
    [SerializeField] private PlayerAnimations anim;
    
    private Vector2 _movement;
    private bool die;
    private void Start()
    {
        anim.die += () => die = true;
    }

    void Update()
    {
        _movement.x = Input.GetAxisRaw("Horizontal");
        _movement.y = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        if (!die)
        {
            rb.velocity = new Vector3(_movement.x * speed, 0, _movement.y * speed);
            anim.Walk(rb.velocity.magnitude > 0f);    
        }
    }
}
