using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCornerCorrect : MonoBehaviour
{
    public float raycastLength;
    public Vector3 cornerRaycastPos;
    public Vector3 innerRaycastPos;
    public bool cornerCorrect;
    public LayerMask ground;

    Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        RaycastCollision();
        if (cornerCorrect)
        {
            CornerCorrect(rb.velocity.y);
            Debug.Log("Corner Correct");
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position - innerRaycastPos + Vector3.up * raycastLength,
                        transform.position - innerRaycastPos + Vector3.up * raycastLength + Vector3.left * raycastLength);
        Gizmos.DrawLine(transform.position + innerRaycastPos + Vector3.up * raycastLength,
                        transform.position + innerRaycastPos + Vector3.up * raycastLength + Vector3.right * raycastLength);
        Gizmos.DrawLine(transform.position + cornerRaycastPos, transform.position + cornerRaycastPos + Vector3.up * raycastLength);
        Gizmos.DrawLine(transform.position - cornerRaycastPos, transform.position - cornerRaycastPos + Vector3.up * raycastLength);
        Gizmos.DrawLine(transform.position + innerRaycastPos, transform.position + innerRaycastPos + Vector3.up * raycastLength);
        Gizmos.DrawLine(transform.position - innerRaycastPos, transform.position - innerRaycastPos + Vector3.up * raycastLength);
    }

    void RaycastCollision()
    {
        cornerCorrect = Physics2D.Raycast(transform.position + cornerRaycastPos, Vector2.up, raycastLength, ground) &&
                        !Physics2D.Raycast(transform.position + innerRaycastPos, Vector2.up, raycastLength, ground) ||
                        Physics2D.Raycast(transform.position - cornerRaycastPos, Vector2.up, raycastLength, ground) &&
                        !Physics2D.Raycast(transform.position - innerRaycastPos, Vector2.up, raycastLength, ground);
    }

    void CornerCorrect(float Yvelocity)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position - innerRaycastPos + Vector3.up * raycastLength,
                                             Vector3.left, raycastLength, ground);
        if (hit.collider != null)
        {
            float newPos = hit.point.x - (transform.position.x - cornerRaycastPos.x);
            transform.position = new Vector3(transform.position.x + newPos, transform.position.y, 0);
            rb.velocity = new Vector2(rb.velocity.x, Yvelocity);
            return;
        }

        hit = Physics2D.Raycast(transform.position + innerRaycastPos + Vector3.up * raycastLength,
                                             Vector3.right, raycastLength, ground);
        if (hit.collider != null)
        {
            float newPos = hit.point.x - (transform.position.x + cornerRaycastPos.x);
            transform.position = new Vector3(transform.position.x + newPos, transform.position.y, 0);
            rb.velocity = new Vector2(rb.velocity.x, Yvelocity);
            return;
        }
    }
}