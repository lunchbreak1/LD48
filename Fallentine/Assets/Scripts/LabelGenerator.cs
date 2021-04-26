using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LabelGenerator // this class will take a Vector2 object and return a label that can be used by the sprite resolver to obtain a sprite
{
    public static string GetLabel(Vector2 vector) // calculates the correct label based on the Vector2
    {
        string label = "";

        if(vector.y > 0)
        {
            label += "north";
        }
        else if (0 > vector.y)
        {
            label += "south";
        }

        if (vector.x > 0)
        {
            label += "east";
        }
        else if (0 > vector.x)
        {
            label += "west";
        }
        return label;
    }
}
