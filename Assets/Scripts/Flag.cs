using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Flag : MonoBehaviour
{
    [SerializeField] private string _sceneName;
    private float _delayForLoadingLevel = 1.5f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        if (player == null)
            return;

        // play flag wave
        Animator animator = GetComponent<Animator>();
        animator.SetTrigger("Raise");
        Debug.Log("Animator activated!");
        
        // load new level
        StartCoroutine(LoadAfterDelay());
    }

    private IEnumerator LoadAfterDelay()
    {
        yield return new WaitForSeconds(_delayForLoadingLevel);
        SceneManager.LoadScene(_sceneName);
    }
}
