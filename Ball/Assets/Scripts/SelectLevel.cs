using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectLevel : MonoBehaviour
{
    

    public void Selection(int level)
    {
        SceneManager.LoadScene(level);
    }
}
