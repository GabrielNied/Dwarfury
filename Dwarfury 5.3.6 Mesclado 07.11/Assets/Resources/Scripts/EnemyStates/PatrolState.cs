using UnityEngine;
using System.Collections;

public class PatrolState : IEnemyState {

	private Enemy enemy;
	private float patrolTimer;
	private float patrolDuration = 10;

	public void Enter(Enemy enemy){
		this.enemy = enemy;
	}

	public void Execute(){
		Patrol ();

		enemy.Move ();

		if (enemy.Target != null && enemy.InMeleeRange) {
			enemy.ChangeState(new AttackState());
		}
	}

	public void Exit(){

	}

	public void OnTriggerEnter(Collider2D other){
		if (other.tag == "Edge") {
			enemy.ChangeDirection ();

		}
		if (enemy.Target != null) {
			enemy.Move ();
		}
	}

	private void Patrol(){

		patrolTimer += Time.deltaTime;

		if (patrolTimer >= patrolDuration) {
			enemy.ChangeState (new IdleState ());
		}
	}
}
