using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumPad : MonoBehaviour
{
    [SerializeField] Text input1;
    [SerializeField] Text input2;
    private void OnMouseDown()
    {
        switch (gameObject.name)
        {
            case "button_0":
                if(input1.text == "-")
                {
                    input1.text = "0";
                }
                else if(input2.text == "-")
                {
                    input2.text = "0";
                }
                break;
            case "button_1":
                if (input1.text == "-")
                {
                    input1.text = "1";
                }
                else if(input2.text == "-")
                {
                    input2.text = "1";
                }
                break;
            case "button_2":
                if (input1.text == "-")
                {
                    input1.text = "2";
                }
                else if (input2.text == "-")
                {
                    input2.text = "2";
                }
                break;
            case "button_3":
                if (input1.text == "-")
                {
                    input1.text = "3";
                }
                else if (input2.text == "-")
                {
                    input2.text = "3";
                }
                break;
            case "button_4":
                if (input1.text == "-")
                {
                    input1.text = "4";
                }
                else if (input2.text == "-")
                {
                    input2.text = "4";
                }
                break;
            case "button_5":
                if (input1.text == "-")
                {
                    input1.text = "5";
                }
                else if (input2.text == "-")
                {
                    input2.text = "5";
                }
                break;
            case "button_6":
                if (input1.text == "-")
                {
                    input1.text = "6";
                }
                else if (input2.text == "-")
                {
                    input2.text = "6";
                }
                break;
            case "button_7":
                if (input1.text == "-")
                {
                    input1.text = "7";
                }
                else if (input2.text == "-")
                {
                    input2.text = "7";
                }
                break;
            case "button_8":
                if (input1.text == "-")
                {
                    input1.text = "8";
                }
                else if (input2.text == "-")
                {
                    input2.text = "8";
                }
                break;
            case "button_9":
                if (input1.text == "-")
                {
                    input1.text = "9";
                }
                else if (input2.text == "-")
                {
                    input2.text = "9";
                }
                break;
            case "green button_001":
                PlayerPrefs.SetString("padInput", input1.text + input2.text);
                break;
            case "red button_001":
               input1.text = "-";
                input2.text = "-";
                break;
            case "yellow button_001":
                if (input2.text == "-")
                {
                    input1.text = "-";
                }
                else
                {
                    input2.text = "-";
                }
                break;
            default:
                break;
        }

        Debug.Log(PlayerPrefs.GetInt("padInput"));
    }
}
