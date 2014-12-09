using UnityEngine;
using System.Collections;

public class Tutorial_DummyScript : MonoBehaviour {

    public Animator anim;
    public Animation animation;
	// Use this for initialization
	void Start () {

        anim = GetComponent<Animator>();
        animation = GetComponent<Animation>();
	}

    public void InflictDamage(float dmg)
    {

        animation.Play("Dummy_Hurt");
        anim.SetTrigger("Attack");
    }
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.L))
            animation.Play("Dummy_Hurt");
	}
}
