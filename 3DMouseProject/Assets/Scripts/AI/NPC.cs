using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Timers;

public class NPC : MonoBehaviour {

	[SerializeField]
	Transform _destination;
	NavMeshAgent _navMeshagent;
	Animator aiAnimator;

	private Timer timer;
	Vector3 newPos;
	public static bool go = true;


	// Use this for initialization
	public void Start (){
		_navMeshagent = this.GetComponent<NavMeshAgent>();
		aiAnimator = GetComponent<Animator>();
		_destination = GameObject.FindGameObjectWithTag ("Player").transform;
		_navMeshagent.autoTraverseOffMeshLink = false;

		// Length of time an enemy sits when it reaches a random destination
		timer = new Timer();
		timer.Interval = 5000;
		timer.Enabled = true;
		timer.Elapsed += new ElapsedEventHandler(OnTimedEvent);

		if(_navMeshagent == null){
			Debug.LogError("Nav Mesh Agent component not found attached to " + gameObject.name);
		}
		else{
			SetDestination();
		}
	}

	void Update () {
		SetDestination ();
	}


	private void SetDestination(){
		
		if (_destination != null && Vector3.Distance (_destination.transform.position, _navMeshagent.transform.position) <= 20) {
			Vector3 targetVector = _destination.transform.position;

			if (Vector3.Distance (_destination.transform.position, _navMeshagent.transform.position) <= 2.5) {
				_navMeshagent.isStopped = true;
				aiAnimator.SetBool ("aiIsWalking", false);
			} else {
				_navMeshagent.isStopped = false;
				aiAnimator.SetBool ("aiIsWalking", true);
			}

			_navMeshagent.SetDestination (targetVector);
		} 

		else {
			
			if (go == true) {
				go = false;
				aiAnimator.SetBool ("aiIsWalking", true);
				newPos = RandomNavSphere (transform.position, 8, -1);
				_navMeshagent.SetDestination (newPos);
				_navMeshagent.isStopped = false;
			}

			if (Vector3.Distance (newPos, _navMeshagent.transform.position) <= 1) {
				_navMeshagent.isStopped = true;
				aiAnimator.SetBool ("aiIsWalking", false);
			}

		}
	}

	public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask) {
		Vector3 randDirection = Random.insideUnitSphere * dist;
		randDirection += origin;

		return randDirection;
	}

	private static void OnTimedEvent(object source, ElapsedEventArgs e){
		go = true;
	}
}
