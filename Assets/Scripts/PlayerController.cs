using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;

    [SerializeField]
    private PlayerType playerType;

    [SerializeField]
    private float speed = 10f;

    [SerializeField]
    private float boundary = 9f;

    [SerializeField]
    private float jumpPower = 100f;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float p1Move = Mathf.Epsilon;
        float p2Move = Mathf.Epsilon;

        if (playerType == PlayerType.P1)
        {
            p1Move = Input.GetAxisRaw("P1Move");
            
            if (Input.GetButtonDown("P1Jump") && transform.position.y == 1)
            {
                rb.AddForce(new Vector3(0, jumpPower, 0));
            }
        }
        else if (playerType == PlayerType.P2 && transform.position.y == 1)
        {
            p2Move = Input.GetAxisRaw("P2Move");
            
            if (Input.GetButtonDown("P2Jump"))
            {
                rb.AddForce(new Vector3(0, jumpPower, 0));
            }
        }

        if (Input.GetButtonDown("P1Move"))
        {

            if (p1Move > Mathf.Epsilon)
            {
                if (transform.position.x > boundary)
                {
                    return;
                }
                transform.position += new Vector3(3f, 0, 0);
            }
            else if (p1Move < Mathf.Epsilon)
            {
                if (transform.position.x < -boundary)
                {
                    return;
                }

                transform.position += new Vector3(-3f, 0, 0);

            }
        }

        if (Input.GetButtonDown("P2Move"))
        {

            if (p2Move > Mathf.Epsilon)
            {
                if (transform.position.x > boundary)
                {
                    return;
                }

                transform.position += new Vector3(3f, 0, 0);
            }
            else if (p2Move < Mathf.Epsilon)
            {
                if (transform.position.x < -boundary)
                {
                    return;
                }

                transform.position += new Vector3(-3f, 0, 0);

            }
        }



        transform.position += new Vector3(0, 0, speed * Time.deltaTime);
    }
}

public enum PlayerType
{
    P1 = 1,
    P2
}
