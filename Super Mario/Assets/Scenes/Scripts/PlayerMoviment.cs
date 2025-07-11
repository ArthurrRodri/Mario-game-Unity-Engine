using UnityEngine;

public class PlayerMoviment : MonoBehaviour
{
    [SerializeField] private float speedPlayer;
    [SerializeField] private float jumpForce;
    [SerializeField] private bool jumpCheck;
    public float points;

    public bool dead;

    void Start()
    {

    }

    void FixedUpdate()
    {
        Moviment();
    }

    private void Update()
    {
        if (dead)
        {
            Destroy(this.gameObject);
        }
    }
    private void Moviment()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");

        gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(horizontal * speedPlayer * Time.deltaTime, 0f));

        if (Input.GetKey(KeyCode.Space) && jumpCheck)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpForce * Time.deltaTime, ForceMode2D.Impulse);
            jumpCheck = false;
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "floor")
        {
            jumpCheck = true;
        }
        if (collision.gameObject.tag == "killemeny")
        {
            Destroy(collision.transform.parent.gameObject);
        }
        if (collision.gameObject.tag == "points")
        {
            points += 10;
            Destroy(collision.transform.parent.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "deadFloor")
        {
            dead = true;
        }
    }

}
