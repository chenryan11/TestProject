using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseUI2_Leave : MonoBehaviour
{
    public GameObject LeaveUI = null;

    public GameObject Home_YesOrNoUI;
    public GameObject DeskTop_YesOrNoUI;

    // Start is called before the first frame update
    void Start()
    {
        Home_YesOrNoUI.SetActive(false);
        DeskTop_YesOrNoUI.SetActive(false);

        if (LeaveUI != null)
        {
            int childCount = LeaveUI.transform.childCount;

            for (int i = 0; i < childCount; i++)
            {
                GameObject child = LeaveUI.transform.GetChild(i).gameObject;

                if (child.name.Equals("Home"))
                {
                    (child.GetComponent<Button>())
                        .onClick
                        .AddListener(Home);
                }
                else if (child.name.Equals("DeskTop"))
                {
                    (child.GetComponent<Button>())
                        .onClick
                        .AddListener(DeskTop);
                }
            }
        }
    }

    private void Home()
    {
        LeaveUI.SetActive(false);

        Home_YesOrNoUI.SetActive(true);
        DeskTop_YesOrNoUI.SetActive(false);
    }

    private void DeskTop()
    {
        LeaveUI.SetActive(false);

        Home_YesOrNoUI.SetActive(false);
        DeskTop_YesOrNoUI.SetActive(true);
    }

}
