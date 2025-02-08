using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float yForce;
    public float xForce;
    public float xDirection;
    private Rigidbody2D enemyRigidbody;

    public int maximumXPosition;
    public int minimumXPosition;

    void Start() {
        enemyRigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Player") {
            Vector2 jumpForce = new Vector2(xForce * xDirection, yForce);
            enemyRigidbody.AddForce(jumpForce);
        }
    }

    private void FixedUpdate() {
        if (transform.position.x <= minimumXPosition) {
            xDirection = 1;
            enemyRigidbody.AddForce(Vector2.right * xForce);
        }
        if (gameObject.transform.position.x >= maximumXPosition) {
            xDirection = -1;
            enemyRigidbody.AddForce(Vector2.left * xForce);
        }

        if (transform.position.y >= 5) {
            enemyRigidbody.AddForce(Vector2.down * yForce);
        }

    }
}
