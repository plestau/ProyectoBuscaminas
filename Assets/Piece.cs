using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Piece : MonoBehaviour
{
    public int x, y;
    public bool bomb;
    public static bool gameOver = false;

    private void OnMouseDown()
    {
        if (gameOver)
        {
            return;
        }
        if (bomb)
        {
            GetComponent<SpriteRenderer>().color = Color.red;
            gameOver = true;
        }
        else
        {
            int bombsAround = Generator.gen.GetBombsAround(x, y);
            TextMeshProUGUI textComponent = transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>();
            textComponent.text = bombsAround.ToString();

            switch (bombsAround)
            {
                case 0:
                    textComponent.color = new Color32(128, 128, 128, 255);
                    break;
                case 1:
                    textComponent.color = new Color32(0, 0, 255, 255);
                    break;
                case 2:
                    textComponent.color = new Color32(0, 128, 0, 255);
                    break;
                case 3:
                    textComponent.color = new Color32(255, 0, 0, 255);
                    break;
                case 4:
                    textComponent.color = new Color32(0, 0, 128, 255);
                    break;
                case 5:
                    textComponent.color = new Color32(128, 0, 0, 255);
                    break;
                case 6:
                    textComponent.color = new Color32(0, 128, 128, 255);
                    break;
                case 7:
                    textComponent.color = new Color32(0, 0, 0, 255);
                    break;
                case 8:
                    textComponent.color = new Color32(128, 128, 228, 255);
                    break;
                default:
                    textComponent.color = Color.clear;
                    break;
            }
        }
    }
}
