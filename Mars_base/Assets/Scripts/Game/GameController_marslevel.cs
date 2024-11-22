using System.Collections;
using System.Collections.Generic;
using KevinIglesias;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.GraphicsBuffer;

public class GameController_marslevel : MonoBehaviour
{

    public enum GameState
    {
        pause,
        play,
        over,

    }

    [Header("Game Objects")]
    public GameObject item1Collect;
    public GameObject item2Collect;
    public GameObject item3Collect;
    public GameObject Item1_dropzone;
    public GameObject Item2_dropzone;
    public GameObject Item3_dropzone;

    public GameObject PlayerAst;
    public GameObject ArrowGPS;

    [Header("HUD Objects")]
    public GameObject Countdown_label;
    public GameObject InitialBoard;
    public GameObject PlayMenu;
    public GameObject PauseMenu;
    public GameObject FailMenu;
    public GameObject OverMenu;
    public float Timer_count;
    public TextMeshProUGUI Timer_label;
    public bool timerOn = false;
    public GameObject TimerGameObject;
    public GameObject TextAlerts;
    public GameObject posView;
    public GameObject posHide;
    public TextMeshProUGUI alertView;
    public int speedText = 90;

    public float speed = 1.0f;

    [Header("Audio Controllers")]
    public AudioSource playSound;
    public AudioListener musicaMenu;
    public GameObject musicaOn;
    public GameObject musicaOff;



    // Start is called before the first frame update
    void Start()
    {

        InitialBoard.SetActive(true);
        PlayMenu.SetActive(false);
        PauseMenu.SetActive(false);

        item1Collect.SetActive(true);
        item2Collect.SetActive(false);
        item3Collect.SetActive(false);
        Item1_dropzone.SetActive(false);
        Item2_dropzone.SetActive(false);
        Item3_dropzone.SetActive(false);
        TimerGameObject.SetActive(false);
        ArrowGPS.SetActive(false);



    }

    // Update is called once per frame
    void Update()
    {
        if (timerOn == true)
        {
            if (Timer_count > 0)
            {
                Timer_count -= Time.deltaTime;
                DisplayTime(Timer_count);
            }
            else
            {
                Timer_count = 0;
                overGame(false);

            }
        }

        if (PlayerAst.GetComponent<GetItem_controller>().itemUptState == GetItem_controller.itemState.getItem1)
        {
            
            item1Collect.SetActive(false);
            Item1_dropzone.SetActive(true);
            ArrowGPS.SetActive(true);
            ArrowGPS.transform.LookAt(Item1_dropzone.transform);
            
        }
        if (PlayerAst.GetComponent<GetItem_controller>().itemUptState == GetItem_controller.itemState.dropItem1)
        {
            Item1_dropzone.SetActive(false);
            item2Collect.SetActive(true);
            ArrowGPS.SetActive(false);

            TextAlerts.transform.position = Vector3.MoveTowards(TextAlerts.transform.position, posView.transform.position, speedText * Time.deltaTime *8);

            alertView.text = string.Format("Volte para o caminhao e pegue o proximo objeto!");
        }
        if (PlayerAst.GetComponent<GetItem_controller>().itemUptState == GetItem_controller.itemState.getItem2)
        {
            item2Collect.SetActive(false);
            Item2_dropzone.SetActive(true);
            ArrowGPS.SetActive(true);
            ArrowGPS.transform.LookAt(Item2_dropzone.transform);

            TextAlerts.transform.position = Vector3.MoveTowards(TextAlerts.transform.position, posHide.transform.position, speedText * Time.deltaTime * 8);

        }
        if (PlayerAst.GetComponent<GetItem_controller>().itemUptState == GetItem_controller.itemState.dropItem2)
        {
            Item2_dropzone.SetActive(false);
            item3Collect.SetActive(true);
            ArrowGPS.SetActive(false);

            TextAlerts.transform.position = Vector3.MoveTowards(TextAlerts.transform.position, posView.transform.position, speedText * Time.deltaTime * 8);
            alertView.text = string.Format("Volte para o caminhao e pegue o proximo objeto. Vamos la, falta pouco!");
        }
        if (PlayerAst.GetComponent<GetItem_controller>().itemUptState == GetItem_controller.itemState.getItem3)
        {
            item3Collect.SetActive(false);
            Item3_dropzone.SetActive(true);
            ArrowGPS.SetActive(true);
            ArrowGPS.transform.LookAt(Item3_dropzone.transform);

            TextAlerts.transform.position = Vector3.MoveTowards(TextAlerts.transform.position, posHide.transform.position, speedText * Time.deltaTime * 8);
        }
        if (PlayerAst.GetComponent<GetItem_controller>().itemUptState == GetItem_controller.itemState.dropItem3)
        {
            Item3_dropzone.SetActive(false);
            ArrowGPS.SetActive(false);
            overGame(true);
            
        }
        

        

    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        Timer_label.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void playGame()
    {
        InitialBoard.SetActive(false);
        PlayerAst.GetComponent<BasicMotionsCharacterController>().enabled = true;

        PlayMenu.SetActive(true);
        PauseMenu.SetActive(false);
        TimerGameObject.SetActive(true);
        timerOn = true;


    }

    public void pauseGame()
    {
        PlayMenu.SetActive(false);
        PlayerAst.GetComponent<BasicMotionsCharacterController>().enabled = false;
        PauseMenu.SetActive(true);
        timerOn = false;
    }

    public void returnToGame()
    {
        PlayMenu.SetActive(true);
        PlayerAst.GetComponent<BasicMotionsCharacterController>().enabled = true;
        PauseMenu.SetActive(false);
        timerOn = true;
    }

    public void overGame(bool finished)
    {
        PlayMenu.SetActive(false);
        PlayerAst.GetComponent<BasicMotionsCharacterController>().enabled = false;
        TimerGameObject.SetActive(false);
        timerOn = false;

        if (finished == true)
        {
            OverMenu.SetActive(true);
        }
        else
        {
            FailMenu.SetActive(true);
            playSound.enabled = true;
        }
    }

    public void restartGame()
    {
        SceneManager.LoadScene("Test1_mars");
    }

    public void backMenuGame()
    {
        SceneManager.LoadScene("Menu");
    }

    public void MusicOnOff()
    {
        if (musicaMenu.enabled == true)
        {
            musicaMenu.enabled = false;
            musicaOff.SetActive(true);
            musicaOn.SetActive(false);
            return;
        }
        if (musicaMenu.enabled == false)
        {
            musicaMenu.enabled = true;
            musicaOff.SetActive(false);
            musicaOn.SetActive(true);
            return;
        }
    }

}
