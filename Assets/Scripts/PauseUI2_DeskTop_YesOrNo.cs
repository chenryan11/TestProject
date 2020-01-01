using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseUI2_DeskTop_YesOrNo : MonoBehaviour
{
    public GameObject DeskTop_YesOrNoUI = null;

    public GameObject LeaveUI;

    void Start()
    {
        DeskTop_YesOrNoUI.SetActive(false);

        if (DeskTop_YesOrNoUI != null)
        {
            int childCount = DeskTop_YesOrNoUI.transform.childCount;

            for (int i = 0; i < childCount; i++)
            {
                GameObject child = DeskTop_YesOrNoUI.transform.GetChild(i).gameObject;

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
        DeskTop_YesOrNoUI.SetActive(false);
        LeaveUI.SetActive(true);
    }
}
