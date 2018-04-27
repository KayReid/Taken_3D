using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPC : MonoBehaviour {

	[SerializeField]
	Transform _destination;

	NavMeshAgent _navMeshagent;

	Animator aiAnimator;

	// Use this for initialization
	public void Start (){
		_navMeshagent = this.GetComponent<NavMeshAgent>();
		aiAnimator = GetComponent<Animator>();
		_destination = GameObject.FindGameObjectWithTag ("Player").transform;

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
		if(_destination != null){
			Vector3 targetVector = _destination.transform.position;

			if (Vector3.Distance (_destination.transform.position, _navMeshagent.transform.position) <= 3){
				_navMeshagent.Stop();
				aiAnimator.SetBool("aiIsWalking", false);
			} else {
				_navMeshagent.Resume();
				aiAnimator.SetBool("aiIsWalking", true);
			}


			if (Vector3.Distance (_destination.transform.position, _navMeshagent.transform.position) >= 20) {
				// MAKE THE ENEMY WONDER AWAY? JUST STOPS NOW
				_navMeshagent.Stop();
				aiAnimator.SetBool("aiIsWalking", false);
			}

			_navMeshagent.SetDestination(targetVector);
		}
	}
}
