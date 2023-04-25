using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed = 0;
    public TextMeshProUGUI countText;
    public TextMeshProUGUI timerText;
    public GameObject winTextObject;
    public GameObject loseTextObject;
    public AudioSource ringbellSound;
    public AudioSource ticTacSound;
    public AudioSource winSound;
    public bool gameActive;

    private Rigidbody rb;
    private int count;
    private float movementX;
    private float movementY;
    private float TTime;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        TTime = 15;
        gameActive = true;

        SetCountText();
        SetTimerText();
        winTextObject.SetActive(false);
        loseTextObject.SetActive(false);

        ticTacSound.Play();
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        
        if (gameActive)
        {
            movementX = movementVector.x;
            movementY = movementVector.y;
        }
        else
        {
            movementX = 0.0f;
            movementY = 0.0f;
        }
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 12)
        {
            winTextObject.SetActive(true);
            gameActive = false;
            ticTacSound.Stop();
            winSound.Play();
        }
    }

    void SetTimerText()
    {
        timerText.text = "Time: " + TTime.ToString("F0");
        if (TTime <= 0)
        {
            ringbellSound.Play();
            loseTextObject.SetActive(true);
            gameActive = false;
            ticTacSound.Stop();
        }
    }

    void FixedUpdate()
    {
        if (gameActive)
        {
            Vector3 movement = new Vector3(movementX, 0.0f, movementY);
            rb.AddForce(movement * speed);
            
            TTime -= Time.deltaTime;
            SetTimerText();
        }
        else
        {
            transform.position = new Vector3(1.5f, 0.5f, 5.0f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
        }
    }
}