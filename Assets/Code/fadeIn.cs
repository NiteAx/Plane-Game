using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fadeIn : MonoBehaviour
{
    public Image blackScreen;
    public float time = 1.5F;
    // Start is called before the first frame update
    void Start()
    {
        FadeFromBlack();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void FadeToBlack()
    {
        blackScreen.color = Color.black;
        blackScreen.canvasRenderer.SetAlpha (0.0f);
        blackScreen.CrossFadeAlpha (1.0f, time, false);
    }
     
    void FadeFromBlack()
    {
        blackScreen.color = Color.black;
        blackScreen.canvasRenderer.SetAlpha (1.0f);
        blackScreen.CrossFadeAlpha (0.0f, time, false);
    }
}
