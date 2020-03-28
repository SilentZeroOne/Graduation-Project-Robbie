using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetLight : MonoBehaviour
{
    public GameObject spotLight;

    private void OnMouseEnter()
    {
        spotLight.SetActive(true);
    }
    private void OnMouseExit()
    {
        spotLight.SetActive(false);
    }
}
