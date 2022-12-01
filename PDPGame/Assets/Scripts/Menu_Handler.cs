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
    public GameObject[] Comp; ///Contains comp
    public Color UI_ColorToChange;
    public Color CurrentColor;
    [Range(0,1)]
    public float LerpedTime;
    Menuloader Loader;
    private bool GoNextScene = false;

    void Start() //init
    {
        Loader = new Menuloader(0.4f,UI_ColorToChange,CurrentColor);
    }

    
    public IEnumerator LoadSceneThread(string NextScene) ////Load next scene
    {   
        var IsDowned = false;

        if (IsDowned == false)
        {
            Comp[3].transform.LeanMoveLocal(new Vector2(6.9141e-0f,-0.00012207f),0.9f).setEaseInOutQuart();
            yield return new WaitForSeconds(0.9f);
            SceneManager.LoadSceneAsync(NextScene); 
        }
    }

    public void LoadScene(string NextScene)
    {
        if (GoNextScene == false)
        {
            GoNextScene = true;
            StartCoroutine(LoadSceneThread(NextScene));
            GoNextScene = false;
        }
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
