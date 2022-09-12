using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Settings : MonoBehaviour
{
    public TextMeshProUGUI pauseText;
    public TextMeshProUGUI forwardText;
    public TextMeshProUGUI backwardText;
    public TextMeshProUGUI leftText;
    public TextMeshProUGUI rightText;
    public TextMeshProUGUI jumpText;
    public TextMeshProUGUI sprintText;
    public TextMeshProUGUI crouchText;
    public TextMeshProUGUI pickUpDropText;
    public TextMeshProUGUI rotateLeftText;
    public TextMeshProUGUI rotateRightText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void defaultSettings(){
        
    }

    public void updateButtonText(TextMeshProUGUI buttonText){
        buttonText.text = "test";
    }
}
