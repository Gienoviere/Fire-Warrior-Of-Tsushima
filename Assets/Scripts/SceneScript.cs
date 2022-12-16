using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneScript : MonoBehaviour
{
    public void LevelSelect()
    {
        SceneManager.LoadScene(1);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void Tutorial()
    {
        SceneManager.LoadScene(2);
    }
    public void Credit()
    {
        SceneManager.LoadScene(3);
    }
    public void Level1()
    {
        SceneManager.LoadScene(4);
    }
    public void Level3()
    {
        SceneManager.LoadScene(5);
    }

    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
