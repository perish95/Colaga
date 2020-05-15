using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Shooter))]
public class PlayerColorSelection : ColorSelector
{
    public Button[] btns;
    public Sprite[] imgs;

    private bool _red = false;
    private bool _blue = false;
    private bool _green = false;
    private string _sceneName;

    private void Start() {
        _sceneName = SceneManager.GetActiveScene().name;
    }

    private void Update()
    {  
        if(_sceneName != SceneManager.GetActiveScene().name){
            _sceneName = SceneManager.GetActiveScene().name;
            btns[0] = GameObject.Find("RedBtn").GetComponent<Button>(); //red
            btns[1] = GameObject.Find("GreenBtn").GetComponent<Button>(); //green
            btns[2] = GameObject.Find("BlueBtn").GetComponent<Button>(); //blue
        }
        if (Input.GetKeyDown(KeyCode.J))
            selectRed();
        if (Input.GetKeyDown(KeyCode.N))
            selectBlue();
        if (Input.GetKeyDown(KeyCode.M))
            selectGreen();
    }

    public void selectRed()
    {
        if (!_red)
        {
            _red = true;
            btns[0].GetComponent<Image>().sprite = imgs[1];
            addColor(ColorType.Red);
            UpdateColors();
        }
        else
        {
            _red = false;
            btns[0].GetComponent<Image>().sprite = imgs[0];
            subColor(ColorType.Red);
            UpdateColors();
        }
    }

    public void selectBlue()
    {
        if (!_blue)
        {
            _blue = true;
            btns[2].GetComponent<Image>().sprite = imgs[1];
            addColor(ColorType.Blue);
            UpdateColors();
        }
        else
        {
            _blue = false;
            btns[2].GetComponent<Image>().sprite = imgs[0];
            subColor(ColorType.Blue);
            UpdateColors();
        }
    }

    public void selectGreen()
    {
        if (!_green)
        {
            _green = true;
            btns[1].GetComponent<Image>().sprite = imgs[1];
            addColor(ColorType.Green);
            UpdateColors();
        }
        else
        {
            _green = false;
            btns[1].GetComponent<Image>().sprite = imgs[0];
            subColor(ColorType.Green);
            UpdateColors();
        }
    }

    public void addColor(ColorType getColor)
    {
        currentColor = currentColor | getColor;
        // Debug.Log(currentColor);
    }

    public void subColor(ColorType getColor)
    {
        currentColor = currentColor ^ getColor;
        // Debug.Log(currentColor);
    }

}
