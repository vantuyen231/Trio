using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    private Animator trasitionAnim;
    void Start()
    {
        trasitionAnim = GetComponent<Animator>();
    }

    public void LoadScene(string sceneName)
    {
        StartCoroutine(Transition(sceneName));
    }
    IEnumerator Transition(string sceneName)
    {
        trasitionAnim.SetTrigger("end");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(sceneName);
    }
}