using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallJump : MonoBehaviour
{
    public Vector2 speed = new Vector2(10, 10);

    private Vector2 movement = new Vector2(1, 1);

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        movement = new Vector2(
            speed.x * inputX,
            speed.y * inputY);

        if (Input.GetKeyDown("up"))
        {
            //transform.Translate(Vector3.up * 260 * Time.deltaTime, Space.World);
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 7), ForceMode2D.Impulse);
        }

    }
}
