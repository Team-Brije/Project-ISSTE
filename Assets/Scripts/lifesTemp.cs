using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class lifesTemp : MonoBehaviour
{
    void Update()
    {
        gameObject.GetComponent<TextMeshProUGUI>().text = GameManager.lives.ToString();
    }
}
