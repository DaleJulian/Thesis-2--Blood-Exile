using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{

    public Transform objectToLookAt;
    public Vector3 myTransform;
    Vector3 myVel;
    public float distance;

    bool intro;

    public Transform[] introTargets;
    public int currentTarget;
    public float cutsceneTimer;
    Vector3 refVel;
    // Use this for initialization
    void Start()
    {
        intro = true;
    }

   
    // Update is called once per frame
    void Update()
    {
        #region intro false
        if (intro == false)
        {
            objectToLookAt = GameObject.Find("Character Manager").GetComponent<CharacterManager>().selectedLeader.transform;

            this.transform.position = Vector3.SmoothDamp(this.transform.position, objectToLookAt.transform.position + new Vector3(0, distance + 1.5f, -distance),
                ref myVel, 0.5f);

            if (Input.GetKey(KeyCode.Keypad8))
            {
                distance -= 0.05f; ;
            }

            if (Input.GetAxis("Mouse ScrollWheel") > 0)
            {
                distance -= 0.3f;
            }
            if (Input.GetKey(KeyCode.Keypad2))
            {
                distance += 0.05f;
            }

            if (Input.GetAxis("Mouse ScrollWheel") < 0)
            {
                distance += 0.3f;
            }

            if (Input.GetAxis("ZoomIn") >= 1)
            {
                distance += 0.1f;
            }

            else if (Input.GetAxis("ZoomIn") <= -1)
            {
                distance -= 0.1f;
            }

            distance = Mathf.Clamp(distance, 2, 8);
            for (int i = 0; i < CharacterManager.instance.myChars.Count; i++)
            {
                CharacterManager.instance.myChars[i].GetComponent<Movements>().canMove = true;
            }
            CharacterManager.instance.canSwitch = true;
        }
        #endregion
        else
        {
            CharacterManager.instance.canSwitch = false;
            for (int i = 0; i < CharacterManager.instance.myChars.Count; i++)
            {
                CharacterManager.instance.myChars[i].GetComponent<Movements>().canMove = false;
            }
            transform.position = Vector3.SmoothDamp(transform.position, introTargets[currentTarget].transform.position, ref refVel, 1.0f);
            if (Input.GetMouseButtonDown(0) || Input.GetButtonDown("Skill 3"))
            {
                currentTarget++;
                cutsceneTimer = 0;
            }
            cutsceneTimer += Time.deltaTime;
            
            if (cutsceneTimer > 5.0f)
            {
                currentTarget++;
                cutsceneTimer = 0;
            }
            if (currentTarget >= introTargets.Length)
            {
                intro = false;
            }
            
            
        }

        

        
    }
}
