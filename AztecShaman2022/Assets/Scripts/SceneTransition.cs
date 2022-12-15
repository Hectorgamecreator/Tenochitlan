using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneTransition : MonoBehaviour
{
    public int SceneIndex;
    int CitizensCount;
    int QuestsDone;
    // Start is called before the first frame update
    void Start()
    {
        CitizensCount=gameObject.GetComponentsInChildren<NPC>().Length;
        QuestsDone = 0;
    }

   public void EndAQuest()
    {
        QuestsDone++;
        if (QuestsDone >= CitizensCount)
            SceneManager.LoadScene(SceneIndex);
    }
}
