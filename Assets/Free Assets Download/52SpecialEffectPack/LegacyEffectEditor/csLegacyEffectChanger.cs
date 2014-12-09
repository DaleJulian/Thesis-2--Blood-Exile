﻿using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;


public class csLegacyEffectChanger : MonoBehaviour {

    public void LegacyEffectScaleChange(float Value)
    {
        ParticleEmitter[] ParticleEmitters = GetComponentsInChildren<ParticleEmitter>();
        ParticleAnimator[] ParticleAnimators = GetComponentsInChildren<ParticleAnimator>();
        ParticleRenderer[] ParticleRenderers = GetComponentsInChildren<ParticleRenderer>();

        transform.localScale *= Value;

        foreach (ParticleEmitter _ParticleEmitter in ParticleEmitters)
        {
            _ParticleEmitter.minSize *= Value;
            _ParticleEmitter.maxSize *= Value;
            _ParticleEmitter.localVelocity *= Value;
            _ParticleEmitter.rndAngularVelocity *= Value;
            _ParticleEmitter.rndVelocity *= Value;
            SerializedObject _SerializedObject = new SerializedObject(_ParticleEmitter);
            _SerializedObject.FindProperty("m_Ellipsoid").vector3Value *= Value;
            _SerializedObject.FindProperty("tangentVelocity").vector3Value *= Value;
            _SerializedObject.ApplyModifiedProperties();
           
        }

        foreach (ParticleAnimator _ParticleAnimator in ParticleAnimators)
        {
            _ParticleAnimator.sizeGrow *= Value;
            _ParticleAnimator.force *= Value;
            _ParticleAnimator.rndForce *= Value;
            
        }

        foreach (ParticleRenderer _ParticleRenderer in ParticleRenderers)
        {
            _ParticleRenderer.maxParticleSize *= Value;
        }
    }
}
#endif
