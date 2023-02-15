using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float movementSpeed = 10;
    public int damage = 1;

    GameManager manager;
    Rigidbody2D body;
    Vector2 direction;
    GameObject player;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        GameObject go = GameObject.FindGameObjectWithTag("GameController");
        manager = go.GetComponent<GameManager>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        //calculate direction to player
        direction = player.transform.position - transform.position;
        direction.Normalize();
        transform.up = direction;
        //set velocity to move toward player
        body.velocity = direction * movementSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("bullet"))
        {
            Destroy(collision.gameObject);
            manager.RecordEnemyDestroyed();
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Player"))
        {
            manager.RecordEnemyDestroyed();
        }
    }
}
