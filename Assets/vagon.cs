using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "vagones", menuName = "ScriptableObjects/vagones", order = 1)]
public class Vagones : ScriptableObject
{
    public int numDianas;
    public int numVagones;
    public float tiempoEnttreVagones;
    public float velocidadDianas;
}
