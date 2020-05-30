using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NewMenu : MonoBehaviour
{
    public GameObject PlayerHUDCanvus = null;

    //public Button btnNewGame;

    /*void Start()
    {
        if (PlayerHUDCanvus != null)
        {
            int childCount = PlayerHUDCanvus.transform.childCount;

            for (int i = 0; i < childCount; i++)
            {
                GameObject child = PlayerHUDCanvus.transform.GetChild(i).gameObject;

                if (child.name.Equals("NewGame"))
                {
                    (child.GetComponent<Button>())
                        .onClick
                        .AddListener(btnNewGame);
                }
            }
        }
    }*/
    /*
    void btnNewGame()
    {
        UnityEngine.Debug.Log("123");
    }*/
    
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            UnityEngine.Debug.Log("123");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //UnityEngine.Debug.Log("123");

            SceneManager.LoadScene("Menu");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
           // UnityEngine.Debug.Log("123");
        }
    }
} 
