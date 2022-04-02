using UnityEngine;
using System.Collections.Generic;

public class HackAttacker : MonoBehaviour
{
	[SerializeField]
	private float movementSpeed = 5.0f;

	private IEnumerator<Transform> pathEnumerator;

	public void Activate(AttackerPath path) {
		pathEnumerator = path.GetNextNode();
		pathEnumerator.MoveNext();
	}

	private void Update() {
		transform.position = Vector2.MoveTowards(transform.position, pathEnumerator.Current.position, Time.deltaTime * movementSpeed);

		if(Vector2.Distance(transform.position, pathEnumerator.Current.position) < 0.001) {
			pathEnumerator.MoveNext();
		}
	}
}
