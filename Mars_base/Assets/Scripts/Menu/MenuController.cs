using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{

    public GameObject firstScreen;
    public GameObject briefingScreen;

    // Start is called before the first frame update
    void Start()
    {
        firstScreen.SetActive(true);
        briefingScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void showBriefing()
    {
        firstScreen.SetActive(false);
        briefingScreen.SetActive(true);
    }

    public void initGame()
    {
        SceneManager.LoadScene("Test1_mars");
    }

}
