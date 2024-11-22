using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [Header("Screens")]
    public GameObject firstScreen;
    public GameObject briefingScreen;

    [Header("Audio Controllers")]
    public AudioSource musicaMenu;
    public GameObject musicaOn;
    public GameObject musicaOff;

    // Start is called before the first frame update
    void Start()
    {
        firstScreen.SetActive(true);
        briefingScreen.SetActive(false);
        musicaOff.SetActive(false);
        musicaOn.SetActive(true);

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

    public void MusicOnOff()
    {
        if(musicaMenu.volume == 1)
        {
            musicaMenu.volume = 0;
            musicaOff.SetActive(true);
            musicaOn.SetActive(false);
            return;
        }
        if (musicaMenu.volume == 0)
        {
            musicaMenu.volume = 1;
            musicaOff.SetActive(false);
            musicaOn.SetActive(true);
            return;
        }
    }

}
