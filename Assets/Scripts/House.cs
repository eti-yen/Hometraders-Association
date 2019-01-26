using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// House isn't really a house anymore but it's where we put people so...
[RequireComponent(typeof(BoxCollider2D))]
public class House : MonoBehaviour
{
	public int capacity = 5;
	public bool limitCapacity = false;
	public List<Person> inhabitants;

    // Start is called before the first frame update
    void Start()
    {
		GetComponent<BoxCollider2D>().isTrigger = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public bool AtCapacity()
	{
		if (limitCapacity && inhabitants.Count > capacity)
			Debug.Log("WAT");
		return limitCapacity && inhabitants.Count == capacity;
	}

	public void AddPerson(Person p)
	{
		if (inhabitants.Contains(p))
			Debug.Log("Attempting to add someone who's already in the house!");
		else
		{
			inhabitants.Add(p);
			//p.house = this;
		}
	}

	public void RemovePerson(Person p)
	{
		if (!inhabitants.Contains(p))
			Debug.Log("Attempting to remove person not in house!");
		else
			inhabitants.Remove(p);
	}

	public bool HasPerson(Person p)
	{
		return inhabitants.Contains(p);
	}
}
