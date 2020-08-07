using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTrigger : MonoBehaviour
{
    public GameObject panel;
    void OnTriggerEnter2D()
    {
        Debug.Log("LEVEL COMPLETE");
        panel.SetActive(true);
    }
}
