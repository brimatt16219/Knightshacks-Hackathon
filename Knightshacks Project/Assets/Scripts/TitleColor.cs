using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleColor : MonoBehaviour
{
    //private Outline border;
    public Text text;
    private Color c;

    public float change;
    float r = 255f;
    float g = 255f;
    float b = 0f;
    float a = 255f;

    bool rmax = true;
    // Start is called before the first frame update
    void Start()
    {
        //border = GetComponent<Outline>();
        text = GetComponent<Text>();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ChangeColor();
        
        //border.effectColor = new Color(r, g, b, a);
        
    }

    void ChangeColor()
    {
        text.color = new Color(Random.Range(0f, 255f), Random.Range(0f, 255f), Random.Range(0f, 255f), a);
    }
}
