﻿using UnityEngine;

[ExecuteInEditMode]
public class SpriteOutline : MonoBehaviour {

    public Color color = Color.white;

    private SpriteRenderer spriteRenderer;


    private void OnEnable()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        UpdateOutline(true);
    }

    private void OnDisable()
    {
        UpdateOutline(false);
    }

    private void Update()
    {
        UpdateOutline(true);
    }

    void UpdateOutline(bool outline)
    {
        MaterialPropertyBlock mpb = new MaterialPropertyBlock();
        spriteRenderer.GetPropertyBlock(mpb);
        mpb.SetFloat("_Outline", outline ? 1f : 0);
        mpb.SetColor("_OutlineColor", color);
        spriteRenderer.SetPropertyBlock(mpb);
    }
}
