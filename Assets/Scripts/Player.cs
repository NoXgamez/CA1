using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //variables
    public float moveSpeed = 10;
    public int health = 5;
    float horizontal;
    float vertical;
    Rigidbody2D body;
    Vector2 velocity;
    Vector3 mousePosition;
    Vector3 direction;
    
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //position and movement
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        
        velocity.x = horizontal * moveSpeed;
        velocity.y = vertical * moveSpeed;
        
        body.velocity = velocity;

        //rotation
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;

        direction = mousePosition - transform.position;
        direction.Normalize();
        transform.up = direction;

        //shoots
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    //bullet variables
    [SerializeField]
    GameObject bulletPrefab;
    [SerializeField]
    float bulletSpeed = 20;

    //shoots
    void Shoot()
    {
        GameObject inst = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        Rigidbody2D bulletBody = inst.GetComponent<Rigidbody2D>();
        bulletBody.velocity = direction * bulletSpeed;
    }

    //taking damage
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("enemy"))
        {
            //removes health when hit
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            health -= enemy.damage;

            Destroy(collision.gameObject);
        }

        //closes game if player has no health
        if(health <= 0)
        {
            Application.Quit();
        }
    }
}
