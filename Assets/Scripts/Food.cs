using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SnakeMain"))
        {
            other.GetComponent<PlayerMovementScript>().AddTail();
            FindObjectOfType<AudioManager>().Play("eat food");
            Destroy(gameObject);
        }
    }
}
