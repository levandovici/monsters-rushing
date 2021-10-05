using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Table
{
    private bool[,] matrix;
    public Coordinates length;


    public Table(int x, int y)
    {
        matrix = new bool[x, y];
        length = new Coordinates(x, y);
    }



    public Table DownSize(int leftOffset, int rightOffset, int bottomOffset, int topOffset)
    {
        int sizeX = length.x - leftOffset - rightOffset;
        int sizeY = length.y - bottomOffset - topOffset;

        Table t = new Table(sizeX, sizeY);

        int xStart = leftOffset;
        int xFinish = length.x - rightOffset;
        int yStart = bottomOffset;
        int yFinish = length.y - topOffset;

        for(int x = xStart; x < xFinish; x++)
        {
            for(int y = yStart; y < yFinish; y++)
            {
                t.SetFree(x - leftOffset, y - bottomOffset, isFree(x, y));
            }
        }

        return t;
    }



    public Coordinates uRandomCoordinates()
    {
        int x = -1;
        int y = -1;

        do
        {
            x = UnityEngine.Random.Range(0, length.x);
            y = UnityEngine.Random.Range(0, length.y);
        }
        while (!isFree(x, y));

        matrix[x, y] = true;

        return new Coordinates(x, y);
    }

    public Coordinates RandomCoordinates()
    {
        Coordinates c = uRandomCoordinates();

        return new Coordinates(c.x - length.x / 2, c.y - length.y / 2);
    }


    public bool isFree()
    {
        for(int i = 0; i < length.x; i++)
        {
            for (int j = 0; j < length.y; j++)
                if (!matrix[i, j])
                    return true;
        }

        return false;
    }

    public bool isFree(Coordinates c)
    {
        return isFree(c.x, c.y);
    }

    private bool isFree(int x, int y)
    {
        return !matrix[x, y];
    }

    private void SetFree(int x, int y, bool free)
    {
        matrix[x, y] = !free;
    }



    public struct Coordinates
    {
        public int x;
        public int y;



        public Coordinates(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
}
