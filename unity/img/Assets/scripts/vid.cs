using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using UnityEngine.Networking;

using System.IO;

public class vid: MonoBehaviour
{
    string path;
    string JSONstring;
    RootObject yumo;

    void Start()
    {
        path = "http://localhost/unity/ar_portal.json";
        WWW www = new WWW(path);
        StartCoroutine(waitandfire(www));

    }
    public void fun(string path1,string name)
    {
        WWW www = new WWW(path1);
        StartCoroutine(LoadFromLikeCoroutine(www, name));

    }

    IEnumerator waitandfire(WWW www)
    {
        Debug.Log("KHDVJCSDV");
        yield return www;
        Debug.Log(www.text);
        yumo  = JsonUtility.FromJson<RootObject>("{\"users\":" + www.text + "}");
        foreach (var questions in yumo.users)
        {
            fun(questions.url, questions.names);
            Debug.Log(questions.url);
            Debug.Log(questions.names);

        }
    }

    IEnumerator LoadFromLikeCoroutine(WWW www,string name)
    {
        Debug.Log("bjhgv");
        yield return www;
        Debug.Log(www);
        AssetBundle bundle = www.assetBundle;
        GameObject cobra = (GameObject)bundle.LoadAsset("cobra");
        Instantiate(cobra);
        Debug.Log("kjbhkb");

    }




}
[System.Serializable]
public class Creature
{
    public int total; 
    public int id;
    public string names;
    public string url;
    
}

[System.Serializable]
public class RootObject
{
    public Creature[] users;
}