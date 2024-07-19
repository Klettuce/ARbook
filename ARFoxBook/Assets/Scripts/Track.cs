using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.XR;
using UnityEngine.XR.ARFoundation;

public class Track : MonoBehaviour
{
    public ARTrackedImageManager manager;

    public List<GameObject> list1 = new List<GameObject>();

    private Dictionary<string, GameObject> dict1 = new Dictionary<string, GameObject>();

    public List<AudioClip> list2 = new List<AudioClip>();
    private Dictionary<string, AudioClip> dict2 = new Dictionary<string, AudioClip>();

    void Start()
    {
        foreach (GameObject o in list1)
        {
            dict1.Add(o.name, o);
        }

        foreach (AudioClip o in list2)
        {
            dict2.Add(o.name, o);
        }
    }

    private void OnEnable()
    {
        manager.trackedImagesChanged += OnChanged;
    }

    private void OnDisable()
    {
        manager.trackedImagesChanged -= OnChanged;
    }
    private void OnChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        foreach (ARTrackedImage t in eventArgs.added)
        {
            UpdateImage(t);
            UpdateSound(t);
        }

        foreach (ARTrackedImage t in eventArgs.updated)
        {
            UpdateImage(t);
        }
    }

    void UpdateImage(ARTrackedImage t)
    {
        string name = t.referenceImage.name;

        if (dict1.TryGetValue(name, out GameObject o))
        {
            if (t.trackingState == UnityEngine.XR.ARSubsystems.TrackingState.Tracking)
            {
                o.transform.position = t.transform.position;
                o.transform.rotation = t.transform.rotation;
                o.SetActive(true);
            }
            else
            {
                o.SetActive(false);
            }
        }
    }

    void UpdateSound(ARTrackedImage t)
    {
        string name = t.referenceImage.name;

        if(dict2.TryGetValue(name, out AudioClip sound))
        {
            GetComponent<AudioSource>().PlayOneShot(sound);
        }
    }
}