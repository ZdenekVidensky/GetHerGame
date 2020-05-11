using System.Collections;
using UnityEngine;

static class AnimationExtensions
{
    public static IEnumerator PlayAndWait(this Animation @this)
    {
        @this.Play();

        while (@this.isPlaying == true)
            yield return null;
    }

    public static IEnumerator PlayAndWait(this Animation @this, string animation)
    {
        @this.Play(animation);

        while (@this.isPlaying == true)
            yield return null;
    }
}
