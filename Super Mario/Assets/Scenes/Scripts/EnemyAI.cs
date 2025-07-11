using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private float speed;

    [SerializeField] private bool otherRunning = true;


    GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        moviment();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "enemyfloor")
        {
            otherRunning = true;
        }
        else if (collision.gameObject.tag == "enemyfloorB")
        {
            otherRunning = false;
        }

        else if (collision.gameObject.tag == "player")
        {
            player.GetComponent<PlayerMoviment>().dead = true;

        }
    }

    private void moviment()
    {
        if (otherRunning)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector3(-speed * Time.deltaTime, 0f, 0f));
        }
        else
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector3(speed * Time.deltaTime, 0f, 0f));
        }

    }
}
