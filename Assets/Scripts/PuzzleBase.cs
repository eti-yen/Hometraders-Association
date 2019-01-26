using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleBase : MonoBehaviour
{
	public static PuzzleBase instance;

	public List<House> houses;
	public List<Person> people;

	private void Awake()
	{
		instance = this;
	}

	public bool IsSolved()
	{
		foreach (House h in houses)
		{
			foreach (Person p in h.inhabitants)
			{
				if (!p.WantsFulfilled())
					return false;
			}
		}
		return true;
	}
	/*
	public bool MovePerson(Person person, House target, House source)
	{
		if (target.inhabitants.Count < target.capacity)
		{
			source.RemovePerson(person);
			target.AddPerson(person);
			return true;
		}
		return false;
	}

	// Person a is from the source house, person b is from the target house
	public void SwapPerson(Person persona, Person personb, House target, House source)
	{
		source.RemovePerson(persona);
		source.AddPerson(personb);
		target.RemovePerson(personb);
		target.AddPerson(persona);
	}*/
}
