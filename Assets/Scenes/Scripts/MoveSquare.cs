using UnityEngine;

public class MoveSquare : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _maxDistance = 10f;
    [SerializeField] private Vector2 _startPosition;

    private Rigidbody2D _rb;
    private Vector2 _moveInput;
    private float _timer;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();

        if (_startPosition == Vector2.zero)
            _startPosition = transform.position;
    }

    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        _moveInput = new Vector2(moveX, moveY).normalized;
    }

    void FixedUpdate()
    {
        _rb.velocity = _moveInput * _speed;

        if (Vector2.Distance(transform.position, _startPosition) > _maxDistance)
        {
            transform.position = _startPosition;
            _rb.velocity = Vector2.zero;
        }

        if (transform.position.x < _startPosition.x)
        {
            transform.position = _startPosition;
            _rb.velocity = Vector2.zero;
        }

        _timer += Time.fixedDeltaTime;
        if (_timer >= 2f)
        {
            Debug.Log($"Velocità: {_rb.velocity}, Posizione: {transform.position}");
            _timer = 0f;
        }
    }
}
