using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode()]

public class ProgressBar : MonoBehaviour
{
    public int maximum;
    public int current;
    public Image Bar;
    int score;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetCurrentFill();
        current = score;
    }

    void GetCurrentFill()
    {
        float fillAmount = (float)current / (float)maximum;
        Bar.fillAmount = fillAmount;
    }
}
