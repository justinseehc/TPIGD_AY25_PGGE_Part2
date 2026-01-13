using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneSound : MonoBehaviour
{
    public AudioClip[] mAudioClips; 
    public float mMinSoundDuration = 10.0f;
    public float mMaxSoundDuration = 20.0f;
    private float mCurrentSoundDuration  = 1.0f;
    private AmbientSound mAmbientSound; 

    void Start()
    {
        mAmbientSound = GameApp.Instance.mAmbientSound;
        StartCoroutine(WaitForDuration ());
    }

    void PlayAmbientSound()
    {
        if (mAudioClips.Length > 0)
        {
            int index = Random.Range(0, mAudioClips.Length - 1); 
            mCurrentSoundDuration = Random.Range(mMinSoundDuration, mMaxSoundDuration); 
            //mAmbientSound.Play(mAudioClips[index]); 
            mAmbientSound.Play(mAudioClips[index], 1.0f, 1.0f); // Pass the volume and pitch values here
            Debug.Log("Playing sound " + index.ToString() + " for " + mCurrentSoundDuration + " secs");
        }
    }

    public IEnumerator WaitForDuration()
    {
        while (true)
        {
            yield return new WaitForSeconds(mCurrentSoundDuration);
            PlayAmbientSound();
        }
    } 
}
