﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using UnityEngine.Video;

public class ControllerNarcisa : MonoBehaviour, ITrackableEventHandler
{
    public GameObject videoplayer, btn_play, btn_pause, btn_stop;
    protected TrackableBehaviour mTrackableBehaviour;

    public void OnTrackableStateChanged(TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus)
    {
        if (newStatus == TrackableBehaviour.Status.DETECTED ||
        newStatus == TrackableBehaviour.Status.TRACKED ||
        newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        {

            Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " found");

            if (mTrackableBehaviour.TrackableName == "narcisadejesus")
            {
                videoplayer.GetComponent<VideoPlayer>().Play();
            }
            OnTrackingFound();
        }
        else if (previousStatus == TrackableBehaviour.Status.TRACKED &&
                  newStatus == TrackableBehaviour.Status.NO_POSE)
        {
            Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " lost");
            videoplayer.GetComponent<VideoPlayer>().Stop();
            OnTrackingLost();
        }
        else
        {
            // For combo of previousStatus=UNKNOWN + newStatus=UNKNOWN|NOT_FOUND
            // Vuforia is starting, but tracking has not been lost or found yet
            // Call OnTrackingLost() to hide the augmentations
            OnTrackingLost();
        }
    }

    void Start()
    {

        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour)
        {
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
        }
    }

    protected virtual void OnTrackingFound()
    {
        var rendererComponents = GetComponentsInChildren<Renderer>(true);
        var colliderComponents = GetComponentsInChildren<Collider>(true);
        var canvasComponents = GetComponentsInChildren<Canvas>(true);

        // Enable rendering:
        foreach (var component in rendererComponents)
            component.enabled = true;

        // Enable colliders:
        foreach (var component in colliderComponents)
            component.enabled = true;

        // Enable canvas':
        foreach (var component in canvasComponents)
            component.enabled = true;
    }


    protected virtual void OnTrackingLost()
    {
        var rendererComponents = GetComponentsInChildren<Renderer>(true);
        var colliderComponents = GetComponentsInChildren<Collider>(true);
        var canvasComponents = GetComponentsInChildren<Canvas>(true);

        // Disable rendering:
        foreach (var component in rendererComponents)
            component.enabled = false;

        // Disable colliders:
        foreach (var component in colliderComponents)
            component.enabled = false;

        // Disable canvas':
        foreach (var component in canvasComponents)
            component.enabled = false;
    }


  
    void Update() { 
     if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {

                //case 1
                if (hit.collider.tag == "Play")
                {
                    videoplayer.GetComponent<VideoPlayer>().Play();
    btn_play.SetActive(false);
                    btn_pause.SetActive(true);
                    btn_stop.SetActive(true);
                }

                //case 2
                if (hit.collider.tag == "Pause")
                {
                    videoplayer.GetComponent<VideoPlayer>().Pause();
btn_play.SetActive(true);
                    btn_pause.SetActive(false);
                    btn_stop.SetActive(true);
                }

                //case 3
                if (hit.collider.tag == "Stop")
                {
                    videoplayer.GetComponent<VideoPlayer>().Stop();
btn_play.SetActive(true);
                    btn_pause.SetActive(true);
                    btn_stop.SetActive(false);
                }
            }
        }
    }
}
