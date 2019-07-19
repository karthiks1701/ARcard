using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

using System.IO;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Vuforia;

public class vid: MonoBehaviour
{
    public GameObject[] goButton;
    public Button left, right, plus, minus;
    public GameObject quad;
    public GameObject childobj, childobj1;
    public List<GameObject> buttonList = new List<GameObject>();
    public GameObject button;
    public GameObject temp;
    public Button[] buttons = new Button[17];
    public RectTransform ParentPanel;
    Renderer m_ObjectRenderer;
    int total;
    string path;
    string JSONstring;
    RootObject yumo;
    private float ScreenWidth;
    AssetBundle bundle;
    int current = 1;




    void Start()
    {
        ScreenWidth = Screen.width;
        quad.active = false;
        plus.onClick.AddListener(() => ButtonClicked());
        minus.onClick.AddListener(() => ButtonClicked());
        left.onClick.AddListener(() => ButtonClicked());
        right.onClick.AddListener(() => ButtonClicked());

        path = "http://192.168.43.141/unity/ar_portal.json";
        WWW www = new WWW(path);
        StartCoroutine(waitandfire(www));
    }
    

    IEnumerator waitandfire(WWW www)
    {
        yield return www;
        Debug.Log(www.text);
        yumo  = JsonUtility.FromJson<RootObject>("{\"users\":" + www.text + "}");
        foreach (var i in yumo.users)
        total = i.total;
        create_button(total);
        
    }





    public void create_button(int g)
    {
        Debug.Log(g);
      
        for (int i = 0; i < g; i++)
        {

            goButton[i] = (GameObject)Instantiate(button);
            goButton[i].transform.localScale *= 2;

            goButton[i].transform.SetParent(ParentPanel, false);
            float val2 = (float)i;
            Debug.Log(i);
            Vector3 vec = goButton[i].transform.position;
            vec.x = 90f;
            vec.y = 600f + 40f * val2;
            vec.z = 90f;
            goButton[i].transform.position = vec;
            buttons[i] = goButton[i].GetComponent<Button>();
            buttons[i].name = i.ToString();
            

            foreach (var k in yumo.users)
                if (i+1==k.id)
                    buttons[i].GetComponentInChildren<Text>().text = k.names;

            buttonList.Add(goButton[i]);
            buttons[i].onClick.AddListener(() => ButtonClicked());
            goButton[i].SetActive(false);
            if (i==1)
            {
                goButton[i].SetActive(true);
                Vector3 vec1 = goButton[i].transform.position;
                vec1.x = 550f;
                vec1.y = 200f;
                vec1.z = 90f;
                goButton[i].transform.position = vec1;

            }
           



        }

    }




    public void ButtonClicked()
    {
        Debug.Log(EventSystem.current.currentSelectedGameObject.name);

        if ((EventSystem.current.currentSelectedGameObject.name == "left"))
        {
            goButton[current].SetActive(false);
            if (current == 0)
                current = total - 1;
            else
                current -= 1;
            

            goButton[current].SetActive(true);
            goButton[current].transform.position = new Vector3(550f, 200f, 90f);


        }

        if ((EventSystem.current.currentSelectedGameObject.name == "right"))
        {
            goButton[current].SetActive(false);
            if (current == total-1)
                current = 0;
            else
                current += 1;


            goButton[current].SetActive(true);
            goButton[current].transform.position = new Vector3(550f, 200f, 90f);


        }



        else if ((EventSystem.current.currentSelectedGameObject.name == "plus") && (childobj1 != null))
        {
            childobj1.transform.localScale *= 2;
        }

        else if ((EventSystem.current.currentSelectedGameObject.name == "minus") && (childobj1 != null))
        {
            childobj1.transform.localScale /= 2;
        }
        else
        {
            for (int j = 0; j < total; j++)
            {
                if (EventSystem.current.currentSelectedGameObject.name == j.ToString())
                {
                    quad.active = false;
                    Destroy(childobj1);
                    foreach (var k in yumo.users)
                        if (k.id == j + 1)
                            if ((k.names).Contains("."))
                                call(k.url);
                            else
                                call1(k.url, k.names);
                }
            }
        }

    }



    // automatically called when game started
    public void call(string url)
    {
        quad.active = true;
        m_ObjectRenderer = quad.GetComponent<Renderer>();
        StartCoroutine(LoadFromLikeCoroutine()); // execute the section independently

        //                                the following will be called even before the load finished
        m_ObjectRenderer.material.color = Color.red;



        IEnumerator LoadFromLikeCoroutine()
        {
            Debug.Log("Loading ....");
            WWW wwwLoader = new WWW(url);

            yield return wwwLoader;

            Debug.Log("Loaded");
            m_ObjectRenderer.material.color = Color.white;              // set white
            m_ObjectRenderer.material.mainTexture = wwwLoader.texture;  // set loaded image
        }

    }
    public void call1(string url, string names)
    {
     
        StartCoroutine(Start());
        IEnumerator Start()
        {

            
            var uwr = UnityWebRequestAssetBundle.GetAssetBundle(url);
            yield return uwr.SendWebRequest();

            // Get an asset from the bundle and instantiate it.

            
           bundle = DownloadHandlerAssetBundle.GetContent(uwr);
           

            
            string bun = "assets/" + names + ".fbx";
            var loadAsset = bundle.LoadAssetAsync<GameObject>(bun);
            yield return loadAsset;

            childobj1 = (GameObject)Instantiate(loadAsset.asset) as GameObject;
            childobj1.transform.localScale /= 500 ;
            Debug.Log(childobj1.name);
            childobj1.transform.position = childobj.transform.position;
            childobj1.transform.rotation = childobj.transform.rotation;
            childobj1.transform.parent = childobj.transform;

            bundle.Unload(false);

        }

    }

    void Update()
    {
        if(childobj1!=null)
            childobj1.transform.Rotate(new Vector3(0, 20, 0) * Time.deltaTime);
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




