using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnNote : MonoBehaviour
{
    public Vector3 startPosition;
    public Vector3 endPosition;
    //public float secondsOfLife;
    public GameObject noteObject;
    //public GameObject[] noteObject = new GameObject[4];
    //public float metronome;
    //private float targetLocation;
    public float spawnRate = 1.0f;
    public int count;

    private IEnumerator Start() 
    {
        yield return StartCoroutine(spawn());
        Destroy(gameObject, 0.1f);
    }

    private IEnumerator spawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnRate);

            Instantiate(noteObject, transform.position, noteObject.transform.rotation);
            noteObject.transform.position += Vector3.right;

      
            yield return new WaitForSeconds(0.50f);
        }

        /*for (int i = 0; i < noteObject.Length; i++)
        {
            while (noteObject[i].transform.position.x < targetLocation)
            {
                noteObject[i].transform.Translate(moveSpeed * Time.deltaTime * Vector3.right);
                yield return null;

                GameObject noteItem = Instantiate(noteObject[i], transform.position, transform.rotation);
                noteItem.transform.parent = gameObject.transform;
                noteItem.name = gameObject.name + "-note";
                //Destroy(noteObject[i], 0.5f);
                yield return new WaitForSeconds(0.55f); //stop infinite spawning
            }
            Destroy(noteObject[i]);
        }*/
    }
    // Update is called once per frame
    /*void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {

            SpawnNote();
        
        }
    }

    /*void SpawnNote()
    {

        Instantiate(noteObject, transform.position, noteObject.transform.rotation);
        Destroy(gameObject, 1.3189f);
        noteObject.transform.position += Vector3.right;
        

    }*/

}
