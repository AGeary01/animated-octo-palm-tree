using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatController : MonoBehaviour
{

    public Camera Cam;
    public Rigidbody2D rigidbody2D;
    private float MaxWidth;
    public Renderer renderer;
    // Use this for initialization
    void Start()
    {
        if (Cam == null)
        {
            Cam = Camera.main;
        }
        {
            rigidbody2D = GetComponent<Rigidbody2D>();
            Vector3 upperCorner = new Vector3(Screen.width, Screen.height, 0.0f);
            Vector3 targetwidth = Cam.ScreenToWorldPoint(upperCorner);
            renderer = GetComponent<Renderer>();
            float hatWidth = renderer.bounds.extents.x;
            MaxWidth = targetwidth.x - hatWidth;
        }
    }

    // Update is called once per physics timeset
    void FixedUpdate()
    {
        Vector3 RawPosition = Cam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 TargetPosition = new Vector3(RawPosition.x, -1.26f, 0.0f);
        float targetwidth = Mathf.Clamp(TargetPosition.x, -MaxWidth + 1, MaxWidth - 1);
        TargetPosition = new Vector3(targetwidth, TargetPosition.y, TargetPosition.z);
        rigidbody2D.MovePosition(TargetPosition);
    }
}

