using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseUI2_Home_YesOrNo : MonoBehaviour
{
    public GameObject Home_YesOrNoUI = null;

    public GameObject LeaveUI;

    void Start()
    {
        Home_YesOrNoUI.SetActive(false);

        if (Home_YesOrNoUI != null)
        {
            int childCount = Home_YesOrNoUI.transform.childCount;

            for (int i = 0; i < childCount; i++)
            {
                GameObject child = Home_YesOrNoUI.transform.GetChild(i).gameObject;

                if (child.name.Equals("Yes"))
                {
                    (child.GetComponent<Button>())
                        .onClick
                        .AddListener(Yes);
                }
                else if (child.name.Equals("No"))
                {
                    (child.GetComponent<Button>())
                        .onClick
                        .AddListener(No);
                }
            }
        }
    }

    private void Yes()
    {
        Application.Quit();
    }

    private void No()
    {
        Home_YesOrNoUI.SetActive(false);
        LeaveUI.SetActive(true);
    }
}
