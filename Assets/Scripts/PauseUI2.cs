using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseUI2 : MonoBehaviour
{
    public GameObject UIRoot = null;

    // Start is called before the first frame update
    void Start()
    {
        if (UIRoot != null)
        {
            int childCount = UIRoot.transform.childCount;

            for (int i = 0; i < childCount; i++)
            {
                GameObject child = UIRoot.transform.GetChild(i).gameObject;

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
        
    }

    public void BackPack()
    {
        Debug.Log("BackPack");
    }

    public void Setting()
    {
        Debug.Log("Setting");
    }

    public void Loading()
    {
        Debug.Log("Loading");
    }

    public void Leave()
    {
        Debug.Log("Leave");
        Application.Quit();
    }
}
