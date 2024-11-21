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

    public itemState itemUptState;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("get_item1"))
        {
            itemUptState = itemState.getItem1;
        }

        if (other.gameObject.CompareTag("get_item2"))
        {
            itemUptState = itemState.getItem2;
        }

        if (other.gameObject.CompareTag("get_item3"))
        {
            itemUptState = itemState.getItem3;
        }

        if (other.gameObject.CompareTag("dropzone_1"))
        {
            itemUptState = itemState.dropItem1;
        }

        if (other.gameObject.CompareTag("dropzone_2"))
        {
            itemUptState = itemState.dropItem2;
        }

        if (other.gameObject.CompareTag("dropzone_3"))
        {
            itemUptState = itemState.dropItem3;
        }
    }
}
