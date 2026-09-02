using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] public float Charge = 0.2f;
    public Rigidbody2D rb;
    private bool GoingUp = false;
    private bool GoingRight = false;
    [SerializeField] private float initialMaxVelocity = 3.0f;
    private float maxVelocity;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        maxVelocity = initialMaxVelocity;
        rb.linearVelocityX = initialMaxVelocity; rb.linearVelocityY = initialMaxVelocity;
    }
    private void FixedUpdate()
    {
        //sistema de velocidad máxima progresiva
        if (rb.linearVelocityX < -maxVelocity)
        {
            rb.linearVelocityX = -maxVelocity;
        }

        if (rb.linearVelocityX > maxVelocity)
        {
            rb.linearVelocityX = maxVelocity;
        }

        if (rb.linearVelocityY < -maxVelocity)
        {
            rb.linearVelocityY = -maxVelocity;
        }

        if (rb.linearVelocityY > maxVelocity)
        {
            rb.linearVelocityY = maxVelocity;
        }

        //sitema de carga rebotes
        if (rb.linearVelocityX < 0 && GoingRight)
        {
            GoingRight = false;
            maxVelocity += Charge;  
            Debug.Log("cambio de dirección hacia la izquierda");
        }

        if (rb.linearVelocityX > 0 && !GoingRight)
        {
            GoingRight = true;
            maxVelocity += Charge;
            Debug.Log("cambio de dirección hacia la derecha");
        }

        if (rb.linearVelocityY < 0 && GoingUp)
        {
            GoingUp = false;
            maxVelocity += Charge;
            Debug.Log("cambio de dirección hacia abajo");
        }

        if (rb.linearVelocityY > 0 && !GoingUp)
        {
            GoingUp = true;
            maxVelocity += Charge;
            Debug.Log("cambio de dirección hacia arriba");
        }

    }
    // Update is called once per frame
    void Update()
    {

    }
}
