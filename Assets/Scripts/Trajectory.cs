using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Trajectory : MonoBehaviour
{
    private GameObject obstacles;
    private GameObject wall;
    public int maxIterations;
    public int maxBounces;

    Scene currentScene;
    Scene predictionScene;

    PhysicsScene2D currentPhysicsScene;
    PhysicsScene2D predictionPhysicsScene;

    List<GameObject> dummyObstacles = new List<GameObject>();
    List<GameObject> walls = new List<GameObject>();

    LineRenderer lineRenderer;
    GameObject dummy;
    Rigidbody2D dummyRb;
    Dummy dummyCollider;

    private GameObject ghost;

    // Start is called before the first frame update
    void Start()
    {
        obstacles = GameObject.Find("Pegs");
        wall = GameObject.Find("Walls");
        Physics2D.simulationMode = SimulationMode2D.Script;

        currentScene = SceneManager.GetActiveScene();
        currentPhysicsScene = currentScene.GetPhysicsScene2D();

        CreateSceneParameters parameters = new CreateSceneParameters(LocalPhysicsMode.Physics2D);
        predictionScene = SceneManager.CreateScene("Prediction", parameters);
        predictionPhysicsScene = predictionScene.GetPhysicsScene2D();

        lineRenderer = GetComponent<LineRenderer>();
        ghost = transform.Find("Ghost").gameObject;
        CopyWalls();

    }

    void FixedUpdate()
    {
        if (currentPhysicsScene.IsValid())
        {
            currentPhysicsScene.Simulate(Time.fixedDeltaTime);
        }
    }

    private void CopyWalls()
    {
        foreach (Transform t in wall.transform)
        {
            if (t.gameObject.GetComponent<Collider2D>() != null)
            {
                GameObject fakeT = Instantiate(t.gameObject);
                fakeT.transform.position = t.position;
                fakeT.transform.rotation = t.rotation;
                Renderer fakeR = fakeT.GetComponent<Renderer>();
                if (fakeR)
                {
                    fakeR.enabled = false;
                }
                SceneManager.MoveGameObjectToScene(fakeT, predictionScene);
                walls.Add(fakeT);
            }
        }
    }
    public void copyAllObstacles()
    {
        foreach (Transform t in obstacles.transform)
        {
            if (t.gameObject.GetComponent<Collider2D>() != null)
            {
                GameObject fakeT = Instantiate(t.gameObject);
                fakeT.transform.position = t.position;
                fakeT.transform.rotation = t.rotation;
                Renderer fakeR = fakeT.GetComponent<Renderer>();
                PegScript peg = fakeT.GetComponent<PegScript>();
                peg.isClone = true;
                if (fakeR)
                {
                    fakeR.enabled = false;
                }
                SceneManager.MoveGameObjectToScene(fakeT, predictionScene);
                dummyObstacles.Add(fakeT);
            }
        }
    }

    public void killAllObstacles()
    {
        foreach (var o in dummyObstacles)
        {
            Destroy(o);
        }
        dummyObstacles.Clear();
    }

    public void predict(GameObject subject, Vector2 currentPosition, Vector2 force, Quaternion rotation)
    {
        if (currentPhysicsScene.IsValid() && predictionPhysicsScene.IsValid())
        {
            if (dummy == null)
            {
                dummy = Instantiate(subject);
                dummyRb = dummy.GetComponent<Rigidbody2D>();
                dummyRb.constraints = RigidbodyConstraints2D.None;
                dummyCollider = dummy.GetComponent<Dummy>();
                SceneManager.MoveGameObjectToScene(dummy, predictionScene);
            }

            dummy.transform.position = currentPosition;
            dummy.transform.rotation = rotation;

            
            dummyRb.AddRelativeForce(force, ForceMode2D.Impulse);
            lineRenderer.positionCount = 0;
            lineRenderer.positionCount = maxIterations;
            

            for (int i = 0; i < maxIterations; i++)
            {
                
                predictionPhysicsScene.Simulate(Time.fixedDeltaTime);
                lineRenderer.SetPosition(i, dummy.transform.position);
                if (dummyCollider.contacts >= maxBounces)
                {
                    lineRenderer.positionCount = i;
                    ghost.SetActive(true);
                    ghost.transform.position = lineRenderer.GetPosition(i-1);
                    
                    i = maxIterations;

                }

            }
            
            Destroy(dummy);
           
        }
    }


    public void EnableRenderer()
    {
        lineRenderer.enabled = true;
    }

    public void DisableRenderer()
    {
        lineRenderer.enabled = false;
        ghost.SetActive(false);
    }
}
