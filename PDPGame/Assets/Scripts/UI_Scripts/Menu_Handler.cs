using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.UI;
using System.Threading.Tasks;
using System.Threading;


public class Menuloader
{   
    
    float YieldTime;
    GameObject Comp;
    Color Lerped_Color;
    Color Defualt;

    private AsyncOperation Loading_Procces;
    

    public Menuloader(float Time,Color ToChange,Color Defualt_RGB)
    {
        YieldTime = Time;
        Lerped_Color = ToChange;
        Defualt = Defualt_RGB;
    }

    public Menuloader()
    {
        
    } ///Scene Handler

    public IEnumerator MouseHoverLoader(GameObject self)///Play the Animation
    {   
        Comp = self.transform.GetChild(0).gameObject;
        Comp.GetComponent<TMP_Text>().color = Lerped_Color;
        self.GetComponent<Image>().color = Defualt;

        self.transform.LeanScale(new Vector2(1.2f,1.2f),YieldTime).setEaseInOutQuart();
        yield return null;
    }

    public IEnumerator MouseLeaveLoader(GameObject self)
    {   
        self.transform.LeanScale(Vector2.one,YieldTime).setEaseLinear();

        Comp.GetComponent<TMP_Text>().color = Defualt;
        self.GetComponent<Image>().color = Lerped_Color;  

        yield return null;
    }


    public IEnumerator LoadingSceneAsync(string NextScene)///LoadScene here
    {
        Loading_Procces = SceneManager.LoadSceneAsync(NextScene);

        while(Loading_Procces.isDone == false)
        {
            Debug.Log(Loading_Procces.progress);

            yield return null;
        }
    }

}

public class Menu_Handler : MonoBehaviour
{     
    public GameObject[] Comp; ///Contains comp
    public Color Title_ColoredToChange;
    public Color TitleCurrentColor;

    [Range(0,1)]
    public float LerpedTime;
    Menuloader Loader;
    

    void Start() //init
    {
        Loader = new Menuloader(0.4f,Title_ColoredToChange,TitleCurrentColor);
    }

    
    public void LoadScene(string NextScene)///loading to Next scene directly
    {
       SceneManager.LoadScene(NextScene); 
    }
    

    public void QuitApp()
    {
        Debug.Log("Quit App"); 
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
