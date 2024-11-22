using System.Collections;
using System.Collections.Generic;
using KevinIglesias;
using UnityEngine;

public class GetItem_controller : MonoBehaviour
{
    public enum itemState
    {
        noItem,
        getItem1,
        getItem2,
        getItem3,
        dropItem1,
        dropItem2,
        dropItem3,
    }

    public GameObject backpackPlayer;
    public itemState itemUptState;

    [Header("Audio Controllers")]
    public AudioSource playSound;
    public AudioClip pickItem;
    public AudioClip dropItem;
    public AudioClip successDrop;

    // Start is called before the first frame update
    void Start()
    {
        backpackPlayer.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("get_item1"))
        {
            playSound.clip = pickItem;
            playSound.Play();
            itemUptState = itemState.getItem1;
            backpackPlayer.SetActive(true);
        }

        if (other.gameObject.CompareTag("get_item2"))
        {
            playSound.clip = pickItem;
            playSound.Play();
            itemUptState = itemState.getItem2;
            backpackPlayer.SetActive(true);
        }

        if (other.gameObject.CompareTag("get_item3"))
        {
            playSound.clip = pickItem;
            playSound.Play();
            itemUptState = itemState.getItem3;
            backpackPlayer.SetActive(true);
        }

        if (other.gameObject.CompareTag("dropzone_1"))
        {
            playSound.clip = dropItem;
            playSound.Play();
            itemUptState = itemState.dropItem1;
            backpackPlayer.SetActive(false);
        }

        if (other.gameObject.CompareTag("dropzone_2"))
        {
            playSound.clip = dropItem;
            playSound.Play();
            itemUptState = itemState.dropItem2;
            backpackPlayer.SetActive(false);
        }

        if (other.gameObject.CompareTag("dropzone_3"))
        {
            playSound.clip = successDrop;
            playSound.Play();
            itemUptState = itemState.dropItem3;
            backpackPlayer.SetActive(false);
        }
    }
}
