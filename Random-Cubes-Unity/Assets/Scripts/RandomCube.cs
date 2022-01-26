/* Created by Steve Salah
 * Date Created: January 24, 2022
 * 
 * Last Edited January 26, 2022
 * Last Edited by Steve Salah
 * 
 * Description: Spawn multiple cubes into the scene.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomCube : MonoBehaviour
{
    public GameObject cubePrefab; //new game object
    public float scalingFactor = 0.95f; //amount each cube will chrink each frame
    public int numberOfCubes = 0;

    [HideInInspector]
    public List<GameObject> gameObjectList; //list for all cubes


    // Start is called before the first frame update
    void Start()
    {
        gameObjectList = new List<GameObject>(); //instantiates y=the list
        
    }

    // Update is called once per frame
    void Update()
    {
        numberOfCubes++; //add to number of cubes

        GameObject gObj = Instantiate<GameObject>(cubePrefab); //creates cube instance

        gObj.name = "Cube" + numberOfCubes; //name of cube instance

        gObj.GetComponent<Renderer>().material.color = new Color(Random.Range(0f,1f), Random.Range(0f,1f), Random.Range(0f,1f));

        gObj.transform.position = Random.insideUnitSphere; //Random location inside a sphere radius of 1 from 0,0,0

        gameObjectList.Add(gObj); //add to list

        List<GameObject> removeList = new List<GameObject>(); //list for removed
        foreach (GameObject goTemp in gameObjectList)
        {
            float scale = goTemp.transform.localScale.x; //records current scale
            scale *= scalingFactor; //scale multiplied by scale factor
            goTemp.transform.localScale = Vector3.one * scale; //transform scale

            if(scale <= 0.1f)
            {
                removeList.Add(goTemp);

            }
        }

        foreach(GameObject goTemp in removeList)
        {
            gameObjectList.Remove(goTemp);
            Destroy(goTemp); //destroysgame object
           
            

        }
        
    }
}
