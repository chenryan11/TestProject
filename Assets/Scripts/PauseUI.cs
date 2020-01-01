using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class PauseUI : MonoBehaviour
{
    public GameObject UIRoot = null;

    public Transform canvas;

    public GameObject lodingScreen;
    public Slider slider;
    public Text progressText;

    int sceneIndex;

    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;

        if (UIRoot != null)
        {
            int childCount = UIRoot.transform.childCount;

            for (int i = 0; i < childCount; i++)
            {
                GameObject child = UIRoot.transform.GetChild(i).gameObject;

                if (child.name.Equals("Resume"))
                {
                    (child.GetComponent<Button>())
                        .onClick
                        .AddListener(Resume);
                }
                if (child.name.Equals("Menu"))
                {
                    (child.GetComponent<Button>())
                        .onClick
                        .AddListener(Menu);
                }
                if (child.name.Equals("Quit"))
                {
                    (child.GetComponent<Button>())
                        .onClick
                        .AddListener(Quit);
                }
            }
        }
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape)) //按Esc暫停
        {
            if (canvas.gameObject.activeInHierarchy == false)
            {
                canvas.gameObject.SetActive(true);
                //InteractionIcon.SetActive(false);
                Time.timeScale = 0;
                //player.GetComponent<FirstPersonController>().enabled = false;
                //interact.GetComponent<Interact>().enabled = false;
                Cursor.lockState = CursorLockMode.Confined;
                Cursor.visible = true;
            }
            else
            {
                canvas.gameObject.SetActive(false);
                //InteractionIcon.SetActive(true);
                Time.timeScale = 1;
                //player.GetComponent<FirstPersonController>().enabled = true;
                //interact.GetComponent<Interact>().enabled = true;
            }
        }
    }

    public void Resume()
    {
        canvas.gameObject.SetActive(false);
        Time.timeScale = 1;
        //player.GetComponent<FirstPersonController>().enabled = true;
        //interact.GetComponent<Interact>().enabled = true;
        //Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;
    }

    public void Menu()
    {
        canvas.gameObject.SetActive(false);
        Time.timeScale = 1;
        //player.GetComponent<FirstPersonController>().enabled = true;
        //interact.GetComponent<Interact>().enabled = true;

        sceneIndex = 0;

        StartCoroutine(LoadAsynchronously(sceneIndex));
    }

    public void Quit()
    {
        Application.Quit();
    }


    IEnumerator LoadAsynchronously(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        lodingScreen.SetActive(true);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);

            slider.value = progress;
            progressText.text = progress * 100f + "%";
            yield return null;
        }
    }
}
