using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Swipe swipeControls;

    Rigidbody rb;
    Vector3 designedPosition;
    bool isMoving, isGrounded;
    int roadNumber = 1;
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        XMovement();
        YMovement();

        transform.position = Vector3.MoveTowards(transform.position, designedPosition, 10f * Time.deltaTime);
    }
    void XMovement()
    {
        if (swipeControls.SwipeLeft && roadNumber>0)
        {
            roadNumber--;
            designedPosition += Vector3.left*3;
            isMoving = true;
        }
        if (swipeControls.SwipeRight && roadNumber<2)
        {
            roadNumber++;
            designedPosition += Vector3.right*3;
            isMoving = true;
        }
        designedPosition.y = transform.position.y;
        designedPosition.z = transform.position.z;
    }
    void YMovement()
    {
        if (swipeControls.SwipeUp)
        {
            rb.AddForce(Vector3.up * 300f);
            
        }
        if (swipeControls.SwipeDown)
        {
            rb.AddForce(Vector3.down * 300f);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
             Destroy(gameObject);
             GameManager.instance.GameOver();
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
              Destroy(gameObject);
             GameManager.instance.GameOver();
        }
    }
}
