using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;
    public float jumpForce;

    private Rigidbody2D _rb;
    private bool _isJumping = false;
    private bool _isWallJumping = false;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!_isWallJumping)
        {
            transform.Translate(speed * Input.GetAxis("Horizontal") * Time.deltaTime,
            0f, speed * Input.GetAxis("Vertical") * Time.deltaTime);
        }

        if(!_isJumping && Input.GetKey(KeyCode.Space))
        {
            _rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            _isJumping = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.gameObject.tag == "Ground") // GameObject is a type, gameObject is the property
        {
            _isJumping = false;
        }
    }
}
