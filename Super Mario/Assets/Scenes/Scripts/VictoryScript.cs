using UnityEngine;
using UnityEngine.SceneManagement;
public class VictoryScript : MonoBehaviour
{
    [SerializeField] private GameObject uiVitoria;

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            uiVitoria.SetActive(true);
        }
    }

    public void buttonRestart()
    {
        SceneManager.LoadScene("SampleScene");
    }

}
