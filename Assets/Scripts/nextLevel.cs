using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class nextLevel : MonoBehaviour
{
    public string NextLevel;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Nextlevel();
        }
    }

    public void Nextlevel()
    {
        SceneManager.LoadScene(NextLevel);
    }
}
