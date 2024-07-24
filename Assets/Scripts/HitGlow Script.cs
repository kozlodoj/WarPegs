using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class HitGlowScript : MonoBehaviour
{

    [SerializeField]
    private float hitDuration = 0.2f;
    private int hitEffectAmount = Shader.PropertyToID("_HitEffectAmount");
    private SpriteRenderer[] spriteRenderers;
    private Material[] materials;
    private float lerpAmount;

    public bool gotHit;

    // Start is called before the first frame update
    void Start()
    {
        HitShaderRoutine();
    }

    // Update is called once per frame
    void Update()
    {
        GlowWhenHit();
    }
    private void HitShaderRoutine()
    {
        spriteRenderers = GetComponentsInChildren<SpriteRenderer>();

        materials = new Material[spriteRenderers.Length];

        for (int i = 0; i < materials.Length; i++)
        {
            materials[i] = spriteRenderers[i].material;
        }
    }
    private float GetLerpValue()
    {
        return lerpAmount;
    }
    private void SetLerpValue(float newValue)
    {
        lerpAmount = newValue;
    }
    private void OnLerpUpdate()
    {
        for (int i = 0; i < materials.Length; i++)
        {
            materials[i].SetFloat(hitEffectAmount, GetLerpValue());
        }
    }
    private void OnLerpComplete()
    {
        DOTween.To(GetLerpValue, SetLerpValue, 0f, hitDuration).OnUpdate(OnLerpUpdate);
    }
    private void GlowWhenHit()
    {
        if (gotHit)
        {
            gotHit = false;
            lerpAmount = 0f;
            DOTween.To(GetLerpValue, SetLerpValue, 1f, hitDuration).SetEase(Ease.OutExpo).OnUpdate(OnLerpUpdate).OnComplete(OnLerpComplete);
        }
    }
}
