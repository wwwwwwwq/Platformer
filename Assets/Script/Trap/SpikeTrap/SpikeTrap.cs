using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrap : MonoBehaviour
{
    public float damage = 10;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerA") || collision.CompareTag("PlayerB"))
        {
            collision.GetComponent<PlayerController>().PlayerHurt(damage);
        }
    }
}
