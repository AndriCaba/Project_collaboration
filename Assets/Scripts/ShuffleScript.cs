using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.TimeZoneInfo;

public class ShuffleScript : MonoBehaviour
{
    public Animator animation;
    public float animationTime;

    public void HideCards()
    {
        StartCoroutine(HideShuffle());
    }
    public void ShowCards()
    {
        StartCoroutine(ShowShuffle());
    }

    IEnumerator HideShuffle()
    {
        animation.SetTrigger("Begin");

        yield return new WaitForSeconds(animationTime);
    }
    IEnumerator ShowShuffle()
    {
        animation.SetTrigger("End");

        yield return new WaitForSeconds(animationTime);
    }
}
