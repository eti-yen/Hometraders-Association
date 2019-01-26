using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

	public void AddPerson(Person p)
	{
		if (inhabitants.Contains(p))
			return;
		else
		{
			inhabitants.Add(p);
			p.house = this;
		}
	}
}
