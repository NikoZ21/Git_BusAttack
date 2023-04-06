using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargingMIssileUi : MonoBehaviour
{
    float x = 0.5f;
    private void Update()
    {
        if (x == 1)
        {
            return;
        }
        x = x + 0.05f * Time.deltaTime;
        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, x);
    }
    public void SetLowAlphaValue()
    {
        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, x);
        x = 0.5f;
    }
}
