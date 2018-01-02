using System.Collections;
using UnityEngine;

public class DestroyOnContact : MonoBehaviour
{
    GameObject player;

    private void start()
    {
        player = GameObject.Find("Hat");
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log(collision.gameObject.tag);
        //if (collision. == "Player")
        //{

        //    Destroy(player);
        //}
        Debug.Log(collision.gameObject.name);
        Destroy(collision.gameObject);
    }
}
