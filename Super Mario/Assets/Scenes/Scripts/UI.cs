using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverPlayer : MonoBehaviour
{
    GameObject player;

    [SerializeField] private Text temp;

    [SerializeField] private float tempF;

    [SerializeField] private Text points;

    [SerializeField] private GameObject uiMorte;

    [SerializeField]
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("player");
    }


    private void Update()
    {
        if (player != null && player.GetComponent<PlayerMoviment>().dead)
        {
            uiMorte.SetActive(true);
        }

        pointsUi();
    }

    private void FixedUpdate()
    {
        Temp();
    }

    private void Temp()
    {
        if (tempF > 0)
        {
            tempF -= Time.deltaTime;
            temp.text = tempF.ToString("F0");
        }
        else
        {
            tempF = 0;
            player.GetComponent<PlayerMoviment>().dead = true;
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene("SampleScene");
    }


    private void pointsUi()
    {
        points.text = player.gameObject.GetComponent<PlayerMoviment>().points.ToString();
    }
}
