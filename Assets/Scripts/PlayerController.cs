using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed = 0;
    private Rigidbody rb;
    private int count;
    private float movementX;
    private float movementY;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;
    public GameObject winnerRocket;

    private bool instantiateCountDown;
    private float timer = 0f;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winTextObject.SetActive(false);
        instantiateCountDown = false;
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (instantiateCountDown && timer > 1.0f) {
            Instantiate(winnerRocket, transform.position, rotation: Quaternion.identity);
            count--;
            SetCountText();
            if (count == 0) {
                instantiateCountDown = false;
            }
            timer = 0f;
        }
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("CollectBitch"))
        {
            Debug.Log("Collect");
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString() + " / 8";
        if (count >= 8)
        {
            instantiateCountDown = true;
        }
    }
}
