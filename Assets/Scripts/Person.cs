using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class Person : MonoBehaviour
{
	public List<FriendWant> beWith;
	public Locations desiredLocation;
	public int wantsRequired = 1;

	public string infoString;
	public LayerMask houseLayer;
	private Vector3 start;
	private Vector3 offset;
	private BoxCollider2D coll;

	private void Start()
	{
		start = transform.position;
		GetComponent<Rigidbody2D>().isKinematic = true;
		coll = GetComponent<BoxCollider2D>();
		if (PuzzleBase.instance)
			PuzzleBase.instance.people.Add(this);
		else
			Debug.Log("No Puzzle Base?!");
	}

	private void OnMouseDown()
	{
		offset = gameObject.transform.position - 
			Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
		Collider2D[] results = new Collider2D[1];
		ContactFilter2D filter = new ContactFilter2D();
		filter.SetLayerMask(houseLayer);
		coll.OverlapCollider(filter, results);
		if (results[0] != null && results[0].GetComponent<House>())
		{
			House h = results[0].GetComponent<House>();
			h.RemovePerson(this);
		}
	}

	private void OnMouseDrag()
	{
		float mouseX = Mathf.Clamp(Input.mousePosition.x, 0, Screen.width);
		float mouseY = Mathf.Clamp(Input.mousePosition.y, 0, Screen.height);
		Vector3 curScreenPoint = new Vector3(mouseX, mouseY, 0);
		Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
		transform.position = curPosition;
	}

	private void OnMouseUp()
	{
		Collider2D[] results = new Collider2D[1];
		ContactFilter2D filter = new ContactFilter2D();
		filter.SetLayerMask(houseLayer);
		coll.OverlapCollider(filter, results);
		if (results[0] != null && results[0].GetComponent<House>())
		{
			House h = results[0].GetComponent<House>();
			if (h.AtCapacity())
				transform.position = start;
			else
				h.AddPerson(this);
		}
	}

	public bool WantsFulfilled()
	{
		Collider2D[] results = new Collider2D[1];
		ContactFilter2D filter = new ContactFilter2D();
		filter.SetLayerMask(houseLayer);
		coll.OverlapCollider(filter, results);
		if (results[0] != null && results[0].GetComponent<House>())
		{
			House h = results[0].GetComponent<House>();
			int wantsFulfilled = 0;
			if (desiredLocation.want.Contains(h))
				wantsFulfilled++;
			else if (desiredLocation.required)
				return false;
			foreach (FriendWant f in beWith)
			{
				if (h.HasPerson(f.want))
					wantsFulfilled++;
				else if (f.required)
					return false;
			}
			if (wantsFulfilled >= wantsRequired)
				return true;
		}
		return false;
	}
}
