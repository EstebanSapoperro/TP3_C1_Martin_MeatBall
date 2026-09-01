using UnityEngine;


public class Movement : MonoBehaviour
{
    public Rigidbody2D rb;
    [Header("Movement")]
    [SerializeField] public float velocity = 8.0f;
    [SerializeField] public float yawMultiplier = 5.0f;
    [SerializeField] public float fricction = 0.05f;

    [SerializeField] private KeyCode UpInput = KeyCode.W;
    [SerializeField] private KeyCode RightInput = KeyCode.D;
    [SerializeField] private KeyCode DownInput = KeyCode.S;
    [SerializeField] private KeyCode LeftInput = KeyCode.A;

    private bool movingUp = false;
    private bool movingDown = false;
    private bool movingRight = false;
    private bool movingLeft = false;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("listo para moverme, , yes sir");

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(UpInput))
            movingUp = true;
        else movingUp = false;

        if (Input.GetKey(DownInput))
            movingDown = true;
        else movingDown = false;

        if (Input.GetKey(RightInput))
            movingRight = true;
        else movingRight = false;

        if (Input.GetKey(LeftInput))
            movingLeft = true;
        else movingLeft = false;


    }
    private void FixedUpdate()
    {
        if (movingRight)
            if (rb.linearVelocityX < 0)
                rb.AddForceX(velocity * yawMultiplier);
            else rb.AddForceX(velocity);


        if (movingLeft)
            if (rb.linearVelocityX > 0)
                rb.AddForceX(-velocity * yawMultiplier);
            else rb.AddForceX(-velocity);


        if (movingUp)
            if (rb.linearVelocityY < 0)
                rb.AddForceY(velocity * yawMultiplier);
            else rb.AddForceY(velocity);

        if (movingDown)
            if (rb.linearVelocityY > 0)
                rb.AddForceY(-velocity * yawMultiplier);
            else rb.AddForceY(-velocity);

        if (movingRight == false && movingLeft == false)
        {
            rb.linearVelocityX += -rb.linearVelocityX * fricction;
        }

        if (movingUp == false && movingDown == false)
        {
            rb.linearVelocityY += -rb.linearVelocityY * fricction;
        }



    }

}

