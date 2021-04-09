using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.Audio;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;




public class PauseManager : MonoBehaviour
{
    public TextMeshProUGUI Text;
    public void menuPlay(){
        Time.timeScale = 1;
        Text.gameObject.SetActive(true);
    }
}
