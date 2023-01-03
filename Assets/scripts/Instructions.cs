using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instructions : MonoBehaviour
{
    public GameObject instruction;

  
    void Okay()
    {
        instruction.SetActive(true);
        Time.timeScale = 1f;
    }

  
}
