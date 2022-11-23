using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Checkpoint : MonoBehaviour
{
    public GameObject[] checkPointVideoWant;
    private TestVideos video;

    private int passVideoWantCheck = -1;
    public int PassVideoWantCheck { get { return passVideoWantCheck; } set { passVideoWantCheck = value; } }
    private void Update()
    {
        //Debug.Log(passVideoWantCheck);
    }
    public void returnToCheckpoint(string nameEspisode)
    {
        switch (nameEspisode)
        {
            case "startter":
                checkPointVideoWant[0].SetActive(true);
                break;
            case "First":
                checkPointVideoWant[1].SetActive(true);
                break;
            case "Second":
                break;
        }
    }
    public void returnToCheckpoint2()
    {
        checkPointVideoWant[passVideoWantCheck].SetActive(true);
        video = checkPointVideoWant[passVideoWantCheck].GetComponent<TestVideos>();
        video.i = video.videoClip.Length-1;
        passVideoWantCheck -= 1;
    }
}
