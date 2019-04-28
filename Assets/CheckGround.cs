using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGround : MonoBehaviour
{
    private BallController player;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponentInParent<BallController>();
    }
    /*Estas funciones identifican si esta tocando el suelo (ground) o no, 
     Se indica desde UNITY, con el tag correspondiente*/
    void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ground")
        {
            player.grounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ground")
        {
            player.grounded = false;
        }
    }
}
