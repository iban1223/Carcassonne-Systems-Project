using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMovement : MonoBehaviour
{
    public float speed = 50;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Update()
        {
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");

            Vector3 tempVect = new Vector3(h, v, 0);
            tempVect = tempVect.normalized * speed * Time.deltaTime;
            rb.MovePosition(rb.transform.position + tempVect);
        }
}
