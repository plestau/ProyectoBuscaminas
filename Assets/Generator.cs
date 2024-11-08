using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Generator : MonoBehaviour
{
    public GameObject piece;
    public int width, height, bombsNumber;
    public GameObject[][] map;

    public static Generator gen;

    private void Start()
    {
        gen = this;
        map = new GameObject[width][];
        for (int i = 0; i < width; i++)
        {
            map[i] = new GameObject[height];
        }

        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                map[i][j] = Instantiate(piece, new Vector3(i, j, 0), Quaternion.identity);
                Piece pieceComponent = map[i][j].GetComponent<Piece>();
                if (pieceComponent != null)
                {
                    pieceComponent.x = i;
                    pieceComponent.y = j;
                }
            }
        }
        
        Camera.main.transform.position = new Vector3(((float)width / 2) - 0.5f, ((float)height / 2) - 0.5f, -10);

        for (int i = 0; i < bombsNumber; i++)
        {
            int x = Random.Range(0, width);
            int y = Random.Range(0, height);
            if (map[x][y].GetComponent<Piece>().bomb)
            {
                i--;
            }
            else
            {
                map[x][y].GetComponent<Piece>().bomb = true;
            }
        }
    }

    public int GetBombsAround(int x, int y)
    {
        int cont = 0;
        if (x > 0 && y < height - 1 && map[x - 1][y + 1].GetComponent<Piece>().bomb)
        {
            cont++;
        }
        if (y < height - 1 && map[x][y + 1].GetComponent<Piece>().bomb)
        {
            cont++;
        }
        if (x < width - 1 && y < height - 1 && map[x + 1][y + 1].GetComponent<Piece>().bomb)
        {
            cont++;
        }
        if (x > 0 && map[x - 1][y].GetComponent<Piece>().bomb)
        {
            cont++;
        }
        if (x < width - 1 && map[x + 1][y].GetComponent<Piece>().bomb)
        {
            cont++;
        }
        if (x > 0 && y > 0 && map[x - 1][y - 1].GetComponent<Piece>().bomb)
        {
            cont++;
        }
        if (y > 0 && map[x][y - 1].GetComponent<Piece>().bomb)
        {
            cont++;
        }
        if (x < width - 1 && y > 0 && map[x + 1][y - 1].GetComponent<Piece>().bomb)
        {
            cont++;
        }
        return cont;
    }
}