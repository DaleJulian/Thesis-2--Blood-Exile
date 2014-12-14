using UnityEngine;
using System.Collections;

public class GameOverScript : MonoBehaviour {

    public FracturedObject fracturedObject;
    public GameObject gg;

    bool fadein = false;
	// Use this for initialization
	void Start () {
        Time.timeScale = 0.5f;
        StartCoroutine(destroy());

        Color color = gg.transform.renderer.material.color;
        color.a = 0.0f;
        gg.transform.renderer.material.color = color;
	}

    IEnumerator destroy()
    {
        yield return new WaitForSeconds(0.5f);
        fracturedObject.Explode(fracturedObject.transform.position, 70.0f);
        fadein = true;
        StartCoroutine(displaygameOverText());
    }

    IEnumerator displaygameOverText()
    {
        Time.timeScale = 1.0f;
        yield return new WaitForSeconds(3.0f);
        Application.LoadLevel(0);
    }
	// Update is called once per frame
	void Update () {

        if (fadein)
        {
            Color color = gg.transform.renderer.material.color;
            color.a += 0.01f;
            gg.transform.renderer.material.color = color;
        }

	}
}
