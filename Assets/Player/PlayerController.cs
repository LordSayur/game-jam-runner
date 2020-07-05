using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        var isClick = Input.GetButtonDown("Horizontal");
        var horizontal = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(0, 0, 10f * Time.deltaTime);
        if (isClick)
        {
            if (horizontal > Mathf.Epsilon)
            {

            transform.position += new Vector3(3f, 0, 0);
            }
            else if (horizontal < Mathf.Epsilon)
            {
                transform.position += new Vector3(-3f, 0, 0);

            }

        }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("JUMP");
                rb.AddForce(new Vector3(0, 100f, 0));
            }
    }
}
