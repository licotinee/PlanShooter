using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f;
    public float padding = 0.8f;
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;
    public int score;
    public bool isShooting;
    public Text scoreText;
    public GameObject UIWin;
    public GameObject UILose;

    private static PlayerController instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
           
        }
        //else
        //{
        //    Destroy(gameObject);
        //}
    }

    public static PlayerController Instance
    {
        get { return instance; }
    }
    void Start()
    {
        Camera mainCamera = Camera.main;
        minX = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        maxX = mainCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;
        minY = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + padding;
        maxY = mainCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - padding;
        //Bullet();
        isShooting = true;
    }

    void Update()
    {
        //float deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        //float deltaY = Input.GetAxis("Vertical") * Time.deltaTime * speed;


        //float newXpos = Mathf.Clamp(transform.position.x + deltaX,minX,maxX);
        //float newYpos = Mathf.Clamp(transform.position.y + deltaY, minY, maxY);
        ////float newXpos = transform.position.x + deltaX;
        ////float newYpos = transform.position.y + deltaY;

        //transform.position = new Vector2(newXpos, newYpos);

        if (Input.GetMouseButton(0))
        {
            Vector2 newPos = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
            transform.position = Vector2.Lerp(transform.position, newPos, 10 * Time.deltaTime);

        }

    }

    public void UpdateScore()
    {   
        if (scoreText)
            scoreText.text = "Score : " + score;
        if(score == 16)
        {
            Invoke("UIWinActice", 2f);
            isShooting = false;
        }
    }

    public void UIWinActice()
    {
        UIWin.SetActive(true);
    }

    public void DelayUIWin()
    {
        Invoke("UILoseActice", 2f);
    }
    public void UILoseActice()
    {
        UILose.SetActive(true);
    }


}
