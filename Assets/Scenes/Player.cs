using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using System;
using UnityEngine.Audio;

public class Player : MonoBehaviour
{
    public float speed = 0;
    private Rigidbody rb;
    private float movementX;
    private float movementY;
    public float power = 0;

    public TextMeshProUGUI countText;
    public GameObject failedText;
    public GameObject endingText;

    int count = 0;

    public AudioSource audioSource;
    public AudioClip collisionSound;

    public Transform planeTransform;
    public float fallThreshold = 1.0f; // 落下判定の閾値
    //private bool isFalling = false; // 落下中かどうかのフラグ
    //private bool isJumping = false; // ジャンプ中かどうかのフラグ

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Rigidbody create
        SetCount();
        endingText.SetActive(false);
        failedText.SetActive(false);
    }

    private void SetCount()
    {
        countText.text = "Count:" + count.ToString();
        if (count >= 2)
        {
            countText.gameObject.SetActive(false);
            endingText.SetActive(true);
        }
    }

    // Update is called once per frame
    void OnMove(InputValue inputValue)
    {
        Vector2 movementVector = inputValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);
    }

    private void OnJump(InputValue _)
    {
        rb.AddForce(new Vector3(0.0f, power + 200, 0.0f));
        //isJumping = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.SetActive(false);

        if (audioSource != null && collisionSound != null)
        {
            audioSource.PlayOneShot(collisionSound);
        }

        count += 1;
        SetCount();
    }

    void OnCollisionEnter(Collision collision)
    {
        //    collision.gameObject.SetActive(false);
        //if (collision.gameObject.CompareTag("jimen"))
        //{
        //    isJumping = false;
        //    Debug.Log("isJumping:" + isJumping);
        //}
    }

    //void Update()
    //{
    //    float distanceToPlane = Mathf.Abs(transform.position.y - planeTransform.position.y);
    //    if (distanceToPlane > fallThreshold && !isJumping)
    //    {
    //        // 落下した場合の処理を行う
    //        if (!isFalling)
    //        {
    //            isFalling = true;
    //            HandleFall();
    //        }
    //    }
    //    else
    //    {
    //        isFalling = false;
    //    }
    //}

    //void HandleFall()
    //{
    //    countText.gameObject.SetActive(false);
    //    failedText.SetActive(true);
    //}
}
