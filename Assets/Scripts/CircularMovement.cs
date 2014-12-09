using UnityEngine;
using System.Collections;

public class CircularMovement : MonoBehaviour {


    public float angleOfRotation = 0;
	public float totalCirculationTimeInSeconds = 5.0f;
	private float speed;
	public float radius = 5.0f;

	Vector3 originalPos;

	void Start()
	{

		originalPos = transform.position;
	}
	void Update()
	{
		speed = (2.0f*Mathf.PI)/totalCirculationTimeInSeconds;

		angleOfRotation += speed * Time.deltaTime;
		Vector3 myPos = new Vector3(Mathf.Cos(angleOfRotation) * radius, Mathf.Sin(angleOfRotation) * radius, 0);
		transform.position = originalPos + myPos;

        if (Input.GetKeyDown(KeyCode.Alpha8))
            Application.LoadLevel(1);
	}
}
