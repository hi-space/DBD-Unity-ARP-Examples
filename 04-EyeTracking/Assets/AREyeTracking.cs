﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.XR.ARKit;

public class AREyeTracking : MonoBehaviour
{

    public GameObject leftEyePrefab;
    public GameObject rightEyePrefab;

    GameObject lefEyeGameObject;
    GameObject rightEyeGameObject;


    ARFaceManager arFaceManager;

    // Start is called before the first frame update
    void Awake()
    {
        arFaceManager = GetComponent<ARFaceManager>();
        Debug.Log("-----arFAaceMAnager----");
        Debug.Log(arFaceManager);

        var support = arFaceManager.descriptor.supportsEyeTracking;
        Debug.Log("support Eye Tracking: " + support.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        foreach (ARFace face in arFaceManager.trackables)
        {
            Debug.Log("leftEye: " + face.leftEye.position);
            Debug.Log("rightEye: " + face.rightEye.position);

            if (face.leftEye && !lefEyeGameObject)
            {
                lefEyeGameObject = Instantiate(leftEyePrefab, face.leftEye);
            }
            if (face.rightEye && !rightEyeGameObject)
            {
                rightEyeGameObject = Instantiate(rightEyePrefab, face.rightEye);
            }

            lefEyeGameObject.transform.position = face.leftEye.position;
            rightEyeGameObject.transform.position = face.rightEye.position;

            leftEyePrefab.transform.rotation = face.leftEye.rotation;
            rightEyePrefab.transform.rotation = face.rightEye.rotation;

        }

    }
}