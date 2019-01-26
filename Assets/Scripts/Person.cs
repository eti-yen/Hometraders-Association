using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Person : MonoBehaviour
{
	public House house;
	private Vector3 offset;
	
	private void OnMouseDown()
	{
		offset = gameObject.transform.position - 
			Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
	}

	private void OnMouseDrag()
	{
		Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
		Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
		transform.position = curPosition;
	}

	private void OnMouseUp()
	{
		
	}

	public bool WantsFulfilled()
	{
		return false;
	}
}
