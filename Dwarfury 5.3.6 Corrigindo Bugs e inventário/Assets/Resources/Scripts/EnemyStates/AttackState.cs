﻿using UnityEngine;
using System.Collections;

public class AttackState : IEnemyState {

	private Enemy enemy;
	private float attackTimer;
	private float attackCooldown = 2;
	private bool canAttack = true;

	public void Enter(Enemy enemy){
		this.enemy = enemy;
	}

	public void Execute(){
		Attack ();

		if (enemy.Target != null) {
			enemy.Move ();
		} else {
			enemy.ChangeState(new IdleState());
		}
	}

	public void Exit(){

	}

	public void OnTriggerEnter(Collider2D other){

	}

	private void Attack(){
		attackTimer += Time.deltaTime;

		if (attackTimer >= attackCooldown){
			canAttack = true;
			attackTimer = 0;
			}
		if (canAttack){
			canAttack = false;
			enemy.MyAnimator.SetTrigger("attack");
			}
	}
}
