using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManeger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       tween();
    }
    public void ReloadScene(int scene)
    {
        SceneManager.LoadScene(scene);

    }

    void tween()
    {
        gameObject.transform.localScale = Vector3.one;
        LeanTween.scale(GetComponent<RectTransform>(), new Vector3(1.1f, 1.1f, 1.1f), 0.6f).setLoopPingPong();      
     

    }
}
