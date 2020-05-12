////////////////////////////////////////////////////////////////////////
//
// Copyright (c) 2018 Audiokinetic Inc. / All Rights Reserved
//
////////////////////////////////////////////////////////////////////////

﻿using UnityEngine;
using System.Collections;

public class SoundMaterial : MonoBehaviour
{
    //public AK.Wwise.Switch material;

    public enum Materials
    {
        DIRT,
        GRASS,
        RUBBLE,
        SAND,
        STONE,
        WATER,
        WOOD
    }

    public Materials material;

    private void Start()
    {
        if (gameObject.name.Contains("Dirt") || gameObject.name.Contains("Road"))
            material = Materials.DIRT;
        else if (gameObject.name.Contains("Grass") || gameObject.name.Contains("Forest"))
            material = Materials.GRASS;
        else if (gameObject.name.Contains("Rubble"))
            material = Materials.RUBBLE;
        else if (gameObject.name.Contains("Sand") || gameObject.name.Contains("Desert"))
            material = Materials.SAND;
        else if (gameObject.name.Contains("Stone"))
            material = Materials.STONE;
        else if (gameObject.name.Contains("Water"))
            material = Materials.WATER;
        else if (gameObject.name.Contains("Wood") || gameObject.name.Contains("Tree"))
            material = Materials.WOOD;
    }
}
