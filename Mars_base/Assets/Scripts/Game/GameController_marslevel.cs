using System.Collections;
using System.Collections.Generic;
using KevinIglesias;
using TMPro;
using UnityEngine;

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

    [Header("HUD Objects")]
    public GameObject Countdown_label;
    public GameObject InitialBoard;
    public GameObject PauseButton;
    public GameObject ReturnButton;
    public float Timer_count;
    public TextMeshProUGUI Timer_label;
    public bool timerOn = false;
    public GameObject TimerGameObject;

    // Start is called before the first frame update
    void Start()
    {

        item1Collect.SetActive(true);
        item2Collect.SetActive(false);
        item3Collect.SetActive(false);
        Item1_dropzone.SetActive(false);
        Item2_dropzone.SetActive(false);
        Item3_dropzone.SetActive(false);
        TimerGameObject.SetActive(false);



    }

    // Update is called once per frame
    void Update()
    {
        //Timer_count -= Time.deltaTime;

        //if (Timer_count <= 0.0f)
        //{
        //    overGame();
        //}
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
                overGame();

            }
        }
        

        //Timer_label.GetComponent<TMPro.TextMeshProUGUI>().text = Timer_count.ToString();

        //Debug.Log(PlayerAst.GetComponent<GetItem_controller>().itemUptState);

        if (PlayerAst.GetComponent<GetItem_controller>().itemUptState == GetItem_controller.itemState.getItem1)
        {
            item1Collect.SetActive(false);
            Item1_dropzone.SetActive(true);
        }
        if (PlayerAst.GetComponent<GetItem_controller>().itemUptState == GetItem_controller.itemState.dropItem1)
        {
            Item1_dropzone.SetActive(false);
            item2Collect.SetActive(true);
        }
        if (PlayerAst.GetComponent<GetItem_controller>().itemUptState == GetItem_controller.itemState.getItem2)
        {
            item2Collect.SetActive(false);
            Item2_dropzone.SetActive(true);
        }
        if (PlayerAst.GetComponent<GetItem_controller>().itemUptState == GetItem_controller.itemState.dropItem2)
        {
            Item2_dropzone.SetActive(false);
            item3Collect.SetActive(true);
        }
        if (PlayerAst.GetComponent<GetItem_controller>().itemUptState == GetItem_controller.itemState.getItem3)
        {
            item3Collect.SetActive(false);
            Item3_dropzone.SetActive(true);
        }
        if (PlayerAst.GetComponent<GetItem_controller>().itemUptState == GetItem_controller.itemState.dropItem3)
        {
            Item3_dropzone.SetActive(false);
            overGame();
            
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

        PauseButton.SetActive(true);
        ReturnButton.SetActive(false);
        TimerGameObject.SetActive(true);
        timerOn = true;


    }

    public void pauseGame()
    {
        PauseButton.SetActive(false);
        PlayerAst.GetComponent<BasicMotionsCharacterController>().enabled = false;
        ReturnButton.SetActive(true);
        timerOn = false;
    }

    public void returnToGame()
    {
        PauseButton.SetActive(true);
        PlayerAst.GetComponent<BasicMotionsCharacterController>().enabled = true;
        ReturnButton.SetActive(false);
        timerOn = true;
    }

    public void overGame()
    {
        PlayerAst.GetComponent<BasicMotionsCharacterController>().enabled = false;
        TimerGameObject.SetActive(false);
    }

    void getItem()
    {

    }

    void dropItem()
    {

    }

}
