using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float playerSpeed;
    private Rigidbody2D rb;
    private Vector2 playerDirection;
    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.isGameOver) // Pastikan permainan belum berakhir sebelum mengambil input
        {
            float directionY = Input.GetAxisRaw("Vertical");
            playerDirection = new Vector2(0, directionY).normalized;
        }
    }

    void FixedUpdate()
    {
        if (!GameManager.isGameOver) // Pastikan permainan belum berakhir sebelum memperbarui pergerakan
        {
            rb.velocity = new Vector2(0, playerDirection.y * playerSpeed);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle") || collision.gameObject.CompareTag("Monster"))
        {
            gameManager.GameOver();
        }
    }
}
