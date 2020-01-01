using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseUI2 : MonoBehaviour
{
    public GameObject PauseUIMenu = null;

    public GameObject BackPackUI;
    public GameObject SettingUI;
    public GameObject LoadingUI;
    public GameObject LeaveUI;

    //public Transform Pause;

    // Start is called before the first frame update
    void Start()
    {
        BackPackUI.SetActive(false);
        SettingUI.SetActive(false);
        LoadingUI.SetActive(false);
        LeaveUI.SetActive(false);

        if (PauseUIMenu != null)
        {
            int childCount = PauseUIMenu.transform.childCount;

            for (int i = 0; i < childCount; i++)
            {
                GameObject child = PauseUIMenu.transform.GetChild(i).gameObject;

                if (child.name.Equals("BackPack"))
                {
                    (child.GetComponent<Button>())
                        .onClick
                        .AddListener(BackPack);
                }
                else if (child.name.Equals("Setting"))
                {
                    (child.GetComponent<Button>())
                        .onClick
                        .AddListener(Setting);
                }
                else if (child.name.Equals("Loading"))
                {
                    (child.GetComponent<Button>())
                        .onClick
                        .AddListener(Loading);
                }
                else if (child.name.Equals("Leave"))
                {
                    (child.GetComponent<Button>())
                        .onClick
                        .AddListener(Leave);
                }
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) //按Esc暫停
        {
            if (PauseUIMenu.gameObject.activeInHierarchy == false)
            {
                PauseUIMenu.gameObject.SetActive(true);
                Time.timeScale = 0;
                Cursor.lockState = CursorLockMode.Confined;
                Cursor.visible = true;
            }
            else
            {
                BackPackUI.SetActive(false);
                SettingUI.SetActive(false);
                LoadingUI.SetActive(false);
                LeaveUI.SetActive(false);
                PauseUIMenu.gameObject.SetActive(false);
                Time.timeScale = 1;
            }
        }
    }

    public void BackPack()
    {
        BackPackUI.SetActive(true);
        SettingUI.SetActive(false);
        LoadingUI.SetActive(false);
        LeaveUI.SetActive(false);
    }

    public void Setting()
    {
        BackPackUI.SetActive(false);
        SettingUI.SetActive(true);
        LoadingUI.SetActive(false);
        LeaveUI.SetActive(false);
    }

    public void Loading()
    {
        BackPackUI.SetActive(false);
        SettingUI.SetActive(false);
        LoadingUI.SetActive(true);
        LeaveUI.SetActive(false);
    }

    public void Leave()
    {
        BackPackUI.SetActive(false);
        SettingUI.SetActive(false);
        LoadingUI.SetActive(false);
        LeaveUI.SetActive(true);
    }
}
