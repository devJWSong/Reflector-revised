﻿using UnityEngine;
using UnityEngine.EventSystems;

public class ShieldAttack : MonoBehaviour, IPointerClickHandler {

	public RectTransform canvas;
	public GameObject bulletPrefab;
	public GameObject shield;
	public GameObject DieEffect;
	public float attackSpeed = 20.0f;
	
	public void OnPointerClick(PointerEventData eventData) {
		GameObject bulletObject = Instantiate(bulletPrefab, shield.transform.position, Quaternion.identity);
		Vector2 attackDir = -(shield.transform.parent.parent.position - shield.transform.position);
		attackDir.Normalize();
		bulletObject.GetComponent<Rigidbody2D>().velocity = attackDir * attackSpeed;
	}
}