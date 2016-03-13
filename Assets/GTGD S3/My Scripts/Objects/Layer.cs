using UnityEngine;
using System.Collections;

public class Layer : Object {

    public new string name { get; set; }
    public int bit { get; set; }

    public Layer(string name, int bit)
    {
        this.name = name;
        this.bit = bit;
    }
}
