using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class House : MonoBehaviour
{
	public int capacity;
	public List<Person> inhabitants;

    // Start is called before the first frame update
    void Start()
    {
        foreach (Person p in inhabitants)
		{
			p.house = this;
		}
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public bool AtCapacity()
	{
		if (inhabitants.Count > capacity)
			Debug.Log("WAT");
		return inhabitants.Count == capacity;
	}

	public void AddPerson(Person p)
	{
		if (inhabitants.Contains(p))
			Debug.Log("Attempting to add someone who's already in the house!");
		else
		{
			inhabitants.Add(p);
			p.house = this;
		}
	}

	public void RemovePerson(Person p)
	{
		if (!inhabitants.Contains(p))
			Debug.Log("Attempting to remove person not in house!");
		else
			inhabitants.Remove(p);
	}
}
