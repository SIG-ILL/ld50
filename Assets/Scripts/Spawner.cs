using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{
	[SerializeField]
	private float activationDelay = 0.0f;
	[SerializeField]
	private float spawnInterval = 2.0f;

	[SerializeField]
	private HackAttacker attacker;
	[SerializeField]
	private AttackerPath path;

	private IEnumerator spawnCoroutine;

	private void Start() {
		spawnCoroutine = SpawnTimerCoroutine();
		StartCoroutine(spawnCoroutine);
	}

	private IEnumerator SpawnTimerCoroutine() {
		yield return new WaitForSeconds(activationDelay);

		while(true) {
			HackAttacker attackerInstance = Instantiate<HackAttacker>(attacker);
			attackerInstance.Activate(path);
			yield return new WaitForSeconds(spawnInterval);
		}		
	}
}
