﻿using UnityEngine;

public class GenericRewind : RewindAbstract
{
    [Tooltip("Tracking active state of the object that this script is attached to")]
    [SerializeField] bool trackObjectActiveState;
    [Tooltip("Tracking Position,Rotation and Scale")]
    [SerializeField] bool trackTransform;
    [SerializeField] bool trackVelocity;
    [SerializeField] bool trackAnimator;
    [SerializeField] bool trackAudio;

    [Tooltip("Enable checkbox on right side to track particles")]
    [SerializeField] OptionalParticleSettings trackParticles;

    public override void Rewind(float seconds)
    {
        Debug.Log("Rewind called on object: " + gameObject.name + " for " + seconds + " seconds");
        if (trackObjectActiveState)
            RestoreObjectActiveState(seconds);
        if (trackTransform)
            RestoreTransform(seconds);
        if (trackVelocity)
            RestoreVelocity(seconds);
        if (trackAnimator)
            RestoreAnimator(seconds);
        if (trackAudio)
            RestoreAudio(seconds);
        if (trackParticles.Enabled)
            RestoreParticles(seconds);
        Debug.Log("Finished rewinding for " + gameObject.name);
    }

    public override void Track()
    {
        if (trackObjectActiveState)
            TrackObjectActiveState();
        if (trackTransform)
            TrackTransform();
        if (trackVelocity)
            TrackVelocity();
        if (trackAnimator)
            TrackAnimator();
        if (trackAudio)
            TrackAudio();
        if (trackParticles.Enabled)
            TrackParticles();      
    }
    private void Start()
    {
        if(trackParticles.Enabled)
            InitializeParticles(trackParticles.Value);
    }
}

