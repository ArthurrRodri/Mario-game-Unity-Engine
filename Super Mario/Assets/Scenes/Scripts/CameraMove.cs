using UnityEngine;

public class CameraMove : MonoBehaviour
{
    GameObject player;

    [SerializeField] private float speed;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("player");
    }


    private void FixedUpdate()
    {
        MoveCam();
    }


    void MoveCam()
    {
        if (!player.GetComponent<PlayerMoviment>().dead)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }
    }
}
