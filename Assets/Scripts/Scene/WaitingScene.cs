using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaitingScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitingLoadData());
    }

    IEnumerator WaitingLoadData()
    {
        yield return new WaitForSeconds(2);
        Debug.Log("LoadScene");
        SceneManager.LoadScene(1);
    }
}
