using UnityEngine;
using System.Collections.Generic;

public class AttackerPath : MonoBehaviour
{
	public Transform FirstNode { get { return nodes[0]; } }

	private List<Transform> nodes;

	public IEnumerator<Transform> GetNextNode() {
		foreach(Transform node in nodes) {
			yield return node;
		}
	}

	private void Awake() {
		nodes = new List<Transform>();

		GetComponentsInChildren<Transform>(true, nodes);
		nodes.Remove(transform);
	}
}
