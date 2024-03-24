using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreenScript : MonoBehaviour
{

    private void Start()
    {

        Cursor.lockState = CursorLockMode.None;
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Restart()
    {
        SceneManager.LoadScene(1);
    }
    public void Play()
    {
        SceneManager.LoadScene(1);
        FindObjectsByType<StudioEventEmitter>(FindObjectsSortMode.None).ToList().ForEach(see => see.Stop());
    }
}
