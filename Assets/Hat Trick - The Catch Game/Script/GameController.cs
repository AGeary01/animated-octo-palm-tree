using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour
{

    public Camera cam;
    public GameObject ball;
    public float timeLeft;
    public Text timerText;
    public GameObject gameOverText;
    public GameObject restartButton;

    private float maxWidth;

    void Start()
    {
        if (cam == null)
        {
            cam = Camera.main;
        }
        Vector3 upperCorner = new Vector3(Screen.width, Screen.height, 0.0f);
        Vector3 targetWidth = cam.ScreenToWorldPoint(upperCorner);
        float ballWidth = ball.GetComponent<Renderer>().bounds.extents.x;
        maxWidth = targetWidth.x - ballWidth;
        StartCoroutine(Spawn());

    }
    void FixedUpdate()
    {
        timeLeft += Time.deltaTime;
        if (timeLeft < 0)
        {
            timeLeft = 0;
        }
        timerText.text = "Time Survived:\n                   " + Mathf.RoundToInt(timeLeft);

    }
    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(2.0f);
        while (timeLeft < 12)
        {
            Vector3 spawnPosition = new Vector3(
                Random.Range(-maxWidth, maxWidth),
                transform.position.y,
                0.0f
                );
            Quaternion spawnRotation = Quaternion.identity;
            Instantiate(ball, spawnPosition, spawnRotation);
            yield return new WaitForSeconds(Random.Range(0.75f, 1.0f));
        }







        //yield return new WaitForSeconds(2.0f);
        //gameOverText.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        restartButton.SetActive(true);
    }
}


