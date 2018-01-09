using UnityEngine;
using System.Collections;

public class HT_Explode : MonoBehaviour
{

    public GameObject explosion;
    public ParticleSystem[] effects;
    GameObject bomb;
    GameObject player;
    private void Start()
    {
        bomb = gameObject;
        player = GameObject.Find("Hat");
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Hat")
        {
            Instantiate(explosion, transform.position, transform.rotation);
            foreach (var effect in effects)
            {
                effect.transform.parent = null;
                effect.Stop();
                Destroy(effect.gameObject, 1.0f);
            }
            Destroy(bomb);
            Destroy(player);
        }
    }
}
