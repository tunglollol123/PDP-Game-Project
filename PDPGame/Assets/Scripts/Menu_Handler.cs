using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;


public interface IAnimator2D
{

    void MouseHover();///Play the Animation
    void MouseLeave();
    void Selected(); ///Select Animation play
}

public class Menu_Handler : MonoBehaviour
{       
    private IEnumerator LoadSceneThread(string NextScene) ////Load next scene
    {   
        yield return new WaitForSecondsRealtime(1.5f);
        SceneManager.LoadSceneAsync(NextScene);
    }

    public void LoadScene(string SceneNext)
    {
        ///Play Animation
        StartCoroutine(LoadSceneThread(SceneNext));
    }

    public void QuitApp()
    {
        print("Quitting App");
    }

    public void MouseHover()///Play the Animation
    {
        print("Mouse Hovering");
    }

    public void MouseLeave()
    {
        print("Mouse Exiting");
    }
}
