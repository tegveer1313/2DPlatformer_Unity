using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverUI;

    private void Start()
    {
        gameOverUI.SetActive(false);
    }

    private void Update()
    {
        if (!GameObject.FindGameObjectWithTag("Enemy"))
        {
            gameOverUI.SetActive(true);
        }
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
