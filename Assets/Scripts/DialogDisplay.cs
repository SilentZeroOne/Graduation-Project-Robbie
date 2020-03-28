using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogDisplay : MonoBehaviour
{
    public GameObject dialog;
    int playerLayer;
    bool isFirst = true;
    private void Start()
    {
        playerLayer = LayerMask.NameToLayer("Player");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isFirst) { 
          if (collision.gameObject.layer == playerLayer)
          {
              dialog.SetActive(true);
          }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        
        isFirst = false;
        Invoke("DialogDisappear", 2f);
    }
    private void DialogDisappear()
    {
        dialog.SetActive(false);
    }
}
