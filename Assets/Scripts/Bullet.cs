using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 30f;
    public Rigidbody2D rb;
    private CameraMovement cameraMovement;
    public GameObject impactEffect;

    // Start is called before the first frame update
    void Start()
    {
        cameraMovement = FindObjectOfType<CameraMovement>();
        rb.velocity = new Vector2(speed, 0);
    }
    void Update()
    {
        if (cameraMovement != null)
        {
            rb.velocity = new Vector2(speed + cameraMovement.cameraSpeed, 0); // Membuat Bullet bergerak sesuai kecepatan kamera
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "BulletBorder")
        {
            Destroy(this.gameObject); // Hapus Peluru
        }
        if (collision.tag == "Monster" || collision.tag == "Obstacle")
        {
            GameObject effect = Instantiate(impactEffect, transform.position, transform.rotation); // Spawn efek Ledakan
            Destroy(this.gameObject); // Hapus Peluru
            Destroy(effect, 0.5f); // Menghapus Efek ledakan dari unity
        }
    }
}
