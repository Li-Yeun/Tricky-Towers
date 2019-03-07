using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abilities : MonoBehaviour {

    [SerializeField] GameObject[] Black, White, Color;
    public bool Lock = false;
    private IEnumerator coroutine;

    // every 2 seconds perform the color()
    private IEnumerator WaitAndColor(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        for (int i = 0; i<4; i++)
        {
            if (White[3].activeSelf == true)
            {
                foreach (GameObject color in Color)
                {
                    color.SetActive(true);
                }
                foreach (GameObject white in White)
                {
                    white.SetActive(false);
                }
                Lock = false;
                yield break;
            }
            if (White[i].activeSelf == false)
            {
                White[i].SetActive(true);
                Black[i].SetActive(false);
                break;
            }
        }
        coroutine = WaitAndColor(0.2f);
        StartCoroutine(coroutine);

    }

    public void UsingAbility()
    {
        foreach(GameObject color in Color)
        {
            color.SetActive(false);
        }

        foreach (GameObject black in Black)
        {
            black.SetActive(true);
        }

        coroutine = WaitAndColor(0.25f);
        StartCoroutine(coroutine);
    }
	// Update is called once per frame
	void Update () {
		
	}
}
