using System.Collections;
using UnityEngine;

public class DestroyOnContact : MonoBehaviour

{
    void OnTriggerExit(Collider other)
    {
        Destroy(gameObject);
    }
}