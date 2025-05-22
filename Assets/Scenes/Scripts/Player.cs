using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int playerNumber = 1; // 1 per Player1, 2 per Player2
    [SerializeField] private float speed = 5f;       // Velocità di movimento orizzontale
    [SerializeField] private float jumpForce = 7f;   // Forza del salto
    [SerializeField] private float maxDistance = 10f;    // Distanza massima dal punto iniziale
    private Vector2 startPosition;                       // Salviamo la posizione iniziale


    private Rigidbody2D rb;
    private bool isJumping = false;  // Serve per evitare salti doppi
    private bool jumpPressed = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Salviamo il riferimento al Rigidbody2D
        startPosition = transform.position;
    }

    void Update()
    {
        // Legge l’input dell’utente per il salto
        string jumpButton = "P" + playerNumber + "Jump";
        if (Input.GetButtonDown(jumpButton) && !isJumping)

        {
            jumpPressed = true;
        }
    }

    void FixedUpdate()
    {
        // Movimento orizzontale con tasti A/D o Frecce
        string horizontalAxis = "P" + playerNumber + "Horizontal";
        float moveX = Input.GetAxis(horizontalAxis);
        rb.velocity = new Vector2(moveX * speed, rb.velocity.y);

        // Gestione del salto
        if (jumpPressed)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isJumping = true;
            jumpPressed = false;
        }

        // Reset posizione se supera la distanza massima
        if (Vector2.Distance(transform.position, startPosition) > maxDistance)
        {
            transform.position = startPosition;
            rb.velocity = Vector2.zero;
        }
    }

    // Quando tocchiamo terra, possiamo di nuovo saltare
    void OnCollisionEnter2D(Collision2D collision)
    {
        isJumping = false;
    }
}
