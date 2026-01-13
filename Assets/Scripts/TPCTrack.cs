using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PGGE;

public class TPCTrack : TPCBase
{
    public TPCTrack(Transform cameraTransform, Transform playerTransform) 
        : base(cameraTransform, playerTransform)
    {
    }

    public override void Update()
    {
        Vector3 targetPos = mPlayerTransform.position;

        // We add the camera offset on the Y-axis. 
        targetPos.y += GameConstants.CameraPositionOffset.y;
        mCameraTransform.LookAt(targetPos);
    }
}
