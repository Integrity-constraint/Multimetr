
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[DisallowMultipleComponent]

public class Outline : MonoBehaviour {

    public Color highlightColor = Color.yellow;
    public float highlightIntensity = 0.5f;
    private Material highlightMaterial;
    private Material originalMaterial;
    private Renderer objectRenderer;
    private bool isHighlighted = false;

    void Start()
    {
        objectRenderer = GetComponent<Renderer>();
        originalMaterial = objectRenderer.material;

        highlightMaterial = new Material(originalMaterial);
        highlightMaterial.color = highlightColor * highlightIntensity;
    }

    void OnMouseEnter()
    {
        if (!isHighlighted)
        {
            objectRenderer.material = highlightMaterial;
            isHighlighted = true;
        }
    }

    void OnMouseExit()
    {
        if (isHighlighted)
        {
            objectRenderer.material = originalMaterial;
            isHighlighted = false;
        }
    }





   
}
