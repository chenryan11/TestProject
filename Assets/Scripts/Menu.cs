using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject UIRoot = null;    //null = 空值

    //public GameObject menucanvas;
    //public GameObject settimgcanvas;
    //public GameObject MenuUIBackGround;

    public GameObject lodingScreen;
    public Slider slider;

    void Start()
    {
        //menucanvas.SetActive(true);
        //settimgcanvas.SetActive(false);
        //MenuUIBackGround.SetActive(true);

        //_animator = GetComponent<Animator>();

        //Cursor.visible = true;
        //Cursor.lockState = CursorLockMode.Confined;
        //掃描Button名稱
        if (UIRoot != null)
        {
            int childCount = UIRoot.transform.childCount;

            for (int i = 0; i < childCount; i++)
            {
                GameObject child = UIRoot.transform.GetChild(i).gameObject;

                if (child.name.Equals("NewGame"))
                {
                    (child.GetComponent<Button>())
                        .onClick
                        .AddListener(NewGame);
                }

                if (child.name.Equals("Loading"))
                {
                    (child.GetComponent<Button>())
                        .onClick
                        .AddListener(Loading);
                }

                if (child.name.Equals("Setting"))
                {
                    (child.GetComponent<Button>())
                        .onClick
                        .AddListener(Setting);
                }

                if (child.name.Equals("Out"))
                {
                    (child.GetComponent<Button>())
                        .onClick
                        .AddListener(Out);
                }
            }
        }

    }

    public void NewGame()
    {
        //鎖住滑鼠
        //Cursor.visible = false;
        //Cursor.lockState = CursorLockMode.Locked;

        //MenuUIBackGround.SetActive(false);

        StartCoroutine(LoadAsynchronously(1));
    }
    public void Loading()
    {
        Debug.Log("Loading");
    }

    public void Setting()
    {
        Debug.Log("Setting");
        //StartCoroutine(LoadAsynchronously(1));
    }
    public void Out()
    {
        Application.Quit();
    }

    //loading
    IEnumerator LoadAsynchronously(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        lodingScreen.SetActive(true);

        //Cursor.visible = false;
        //Cursor.lockState = CursorLockMode.Locked;

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress);

            slider.value = progress;
            yield return null;

        }
    }
}

