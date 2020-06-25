using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogoFade : MonoBehaviour
{
    public GameObject logo;
    public GameObject logoPanel;
    public Image pic;
    public Image background;
    private float timer = 0;
    private Vector3 inc;
    public bool fade;
    public bool up = false;
    private float alpha = 0;
    private float balpha = 1f;
    // Start is called before the first frame update
    void Start()
    {
        inc = new Vector3(0.001f, 0.001f, 0.001f);
        if (!MainMenu.getLoaded())
        {
            logoPanel.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (logoPanel.activeSelf)
        {
            if (fade)
            {
                if (alpha < 1 && !up)
                {
                    alpha += 0.005f;
                    var tempColor = pic.color;
                    tempColor.a = alpha;
                    pic.color = tempColor;
                }
                if (alpha >= 1 && !up)
                {
                    up = true;
                }
                if(alpha > 0 && up)
                {
                    alpha -= 0.005f;
                    var tempColor = pic.color;
                    tempColor.a = alpha;
                    pic.color = tempColor;
                }
                if (alpha <= 0 && up)
                {
                    balpha -= 0.005f;
                }
                if(balpha < 1 && balpha > 0)
                {
                    balpha -= 0.005f;
                    var tempColor1 = background.color;
                    tempColor1.a = balpha;
                    background.color = tempColor1;
                }
                if (balpha <= 0)
                {
                    logoPanel.SetActive(false);
                    MainMenu.setLoaded(true);
                }
            }
            else
            {
                logo.transform.localScale += inc;
                if (timer > 3)
                {
                    logoPanel.SetActive(false);
                    MainMenu.setLoaded(true);
                }
            }
            timer += Time.deltaTime;
        }
    }
}
