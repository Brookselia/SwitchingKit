using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Renderer))]
public class ColorChange : MonoBehaviour
{
    [Header("Header")]
    [SerializeField]
    [Tooltip("Colorchange1")]
    private Color color1 = Color.red;
    [Space]
    [SerializeField]
    [Tooltip("Colorchange2")]
    private Color color2 = Color.green;
    [SerializeField]
    private List <Color> colorList;
    [Space]
    [SerializeField]
    [Tooltip("Timeamount")]
    [Range(0.01f, 10)]
    private float duration = 2.0f;
    private Renderer renderer;
    private bool colordirection = true;
    private float amount = 0.0f;
    private Color colorA;
    private Color colorB;


    // Start is called before the first frame update
    void Start()
    {
       
        renderer = GetComponent<Renderer>();
        if (colorList.Count >= 2)
        {
            colorA = colorList[0];
            colorB = colorList[1];
        }
        else
             renderer.material.color = color1;
    }

    // Update is called once per frame
    void Update()
  {
        amount += Time.deltaTime;
        if (colorList.Count>2){
            renderer.material.color = Color.Lerp(colorA, colorB, amount / duration);
            if (renderer.material.color == colorB)
            {
                colorA = colorB;
                int idx = colorList.IndexOf(colorB);
                if (idx +1 == colorList.Count)
                {
                    colorB = colorList[0];
                }
                else
                {
                    colorB = colorList[idx + 1];
                }
                amount = 0f;
            }
        }
        else { 
        if (colordirection)
        {
            renderer.material.color = Color.Lerp(color1, color2, amount / duration);
            if (renderer.material.color == color2)
            {
                colordirection = false;
                amount = 0f;
            }
        }
        else
        {
            renderer.material.color = Color.Lerp(color2, color1, amount / duration);
            if (renderer.material.color == color1)
            {
                colordirection = true;
                amount = 0f;
            }
        }
    }
    }
}
