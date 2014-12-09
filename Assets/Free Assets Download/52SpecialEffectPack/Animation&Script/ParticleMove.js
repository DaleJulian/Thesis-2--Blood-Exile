
public var speed : float = 0f;

function Update () {
	transform.Translate(Vector3.forward * speed);
}