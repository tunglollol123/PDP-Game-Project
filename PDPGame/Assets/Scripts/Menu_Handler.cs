using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using TMPro;



public class Menuloader
{   
    
    float YieldTime;
    GameObject Comp;
    Color Lerped_Color;
    Color Defualt;

    public Menuloader(float Time,Color ToChange,Color Defualt_RGB)
    {
        YieldTime = Time;
        Lerped_Color = ToChange;
        Defualt = Defualt_RGB;
    }

    public IEnumerator MouseHoverLoader(GameObject self)///Play the Animation
    {   
        Comp = self.transform.GetChild(0).gameObject;
        Comp.GetComponent<TMP_Text>().color = Lerped_Color;

        self.transform.LeanScale(new Vector2(1.2f,1.2f),YieldTime).setEaseInOutQuart();
        yield return null;
    }

    public IEnumerator MouseLeaveLoader(GameObject self)
    {   
        self.transform.LeanScale(Vector2.one,YieldTime).setEaseLinear();

        Comp.GetComponent<TMP_Text>().color = Defualt;

        yield return null;
    }
}

public class Menu_Handler : MonoBehaviour
{     

    public Color UI_ColorToChange;
    public Color CurrentColor;
    [Range(0,1)]
    public float LerpedTime;
    Menuloader Loader;

    void Start()
    {
        Loader = new Menuloader(0.4f,UI_ColorToChange,CurrentColor);
    }

    
    private IEnumerator LoadSceneThread(string NextScene) ////Load next scene
    {   
        yield return new WaitForSecondsRealtime(1.5f);
        SceneManager.LoadSceneAsync(NextScene);
    }

    public void LoadScene(string SceneNext)
    {
        ///Play Transformation animation
        StartCoroutine(LoadSceneThread(SceneNext));

    }

    public void QuitApp()
    {
        
    }
    
    public void MouseHover(GameObject Self)
    {
        StartCoroutine(Loader.MouseHoverLoader(Self));

        StopCoroutine(Loader.MouseHoverLoader(Self));
    }

    public void MouseExit(GameObject Self)
    {
        StartCoroutine(Loader.MouseLeaveLoader(Self));


        StopCoroutine(Loader.MouseLeaveLoader(Self));
    }
   
}
