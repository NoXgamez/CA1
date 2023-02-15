using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //destroys bullet if hits barrier
        if (collision.gameObject.CompareTag("barrier"))
        {
            Destroy(gameObject);
        }
    }
}
