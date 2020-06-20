using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineHit : MonoBehaviour
{

    public List<GameObject> lineHits;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowHits() 
    {
        StartCoroutine(Show());
    }

    IEnumerator Show() 
    {
        for (int i = 0; i < 3; i++) 
        {
            for (int j = 0; j < lineHits.Count; j++) 
            {
                lineHits[j].SetActive(true);
                if (j == 0)
                {
                    lineHits[lineHits.Count - 1].SetActive(false);
                }
                else
                {
                    lineHits[j - 1].SetActive(false);
                }
                yield return new WaitForSeconds(0.09f);
            }
        }
        lineHits[lineHits.Count - 1].SetActive(false);
    }
}
