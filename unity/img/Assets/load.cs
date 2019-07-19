using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class load : MonoBehaviour
{
    private GameObject m;
  IEnumerator Start()
    {
        using (WWW www = new WWW("http://localhost/unity/img/cobra"))
        {
            yield return www;

            // Get the designated main asset and instantiate it.
           m = Instantiate(www.assetBundle.LoadAsset("cobra")) as GameObject;
        }
    }
}