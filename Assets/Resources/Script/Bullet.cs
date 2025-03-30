using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    [SerializeField] int speed = 1000;
    [SerializeField] GameObject Camera1;
    [SerializeField] GameObject Cam1_over;
    [SerializeField] GameObject Camera2;
    [SerializeField] GameObject Cam2_over;
    private int aux = 0;
    private bool stay = false;
    private GameObject auxgo = null;
    void Start()
    {
        aux = Random.Range(1, 3);
        aux = 2;
        switch(aux) 
        {

            case 1:
                Camera1.GetComponent<Camera>().enabled = true;
                break;

            case 2:
                Camera2.GetComponent<Camera>().enabled = true;
                break;

        }
        Invoke("_Destroy", 1.8f);

        Time.fixedDeltaTime = 0.01F;
        Time.maximumDeltaTime = 0.01F;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag( "Limit")) { _Destroy(); }

        if (other.gameObject.CompareTag("Body") || other.gameObject.CompareTag("Neck") || other.gameObject.CompareTag("Head")) {
            speed = 666;
            Invoke("CreateBlood", 0.0005f);

            other.transform.root.GetComponent<Animator>().SetBool("Die", true);
            other.transform.root.gameObject.GetComponentInChildren<EnemyAudioManager>().PlayDie();
        }
        if (other.gameObject.CompareTag( "Radius"))
        {
            auxgo = other.transform.root.gameObject;
            SlowMotionR(true);
        }
        if (other.gameObject.CompareTag ("Pelvis"))
        {

            switch (aux)
            {
                case 1:
                    Cam1_over.GetComponent<Renderer>().enabled = true;
                    break;
                case 2:
                    Cam2_over.GetComponent<Renderer>().enabled = true;
                    break;
            }
            SlowMotion(true);
        }
        Camera2.GetComponent<Camera>().enabled = true;


    }
    void CreateBlood() { StartCoroutine(CreateBlood_()); }
    IEnumerator CreateBlood_()
    {
        for (int i = 0; i < 30; i++)
        {                                       //You can add more blood, by setting a bigger bucle
            if (speed != 10 && speed != 667)
            {
                GameObject go = Instantiate(Resources.Load("Prefab/Blood/Blood" + Random.Range(1, 9)), transform.position, Quaternion.Euler(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360))) as GameObject;
            }
            yield return new WaitForSeconds(Random.Range(0, 0.00009f)); //Time between bloods creation
        }
    }
    void Update()
    {
        transform.Translate(Vector3.back * Time.deltaTime * speed);

    }

    void OnTriggerExit(Collider other)
    {
        Time.timeScale = 0.05F;
        Time.fixedDeltaTime = 0.01F * Time.timeScale;
    }
    private void SlowMotionR(bool on)
    {       
        if (on == true)
            Time.timeScale = 0.02F;
        else
            Time.timeScale = 1.0F;
        Time.fixedDeltaTime = 0.02F * Time.timeScale;
    }
    private void _Destroy()
    {
     
            Time.timeScale = 1.0F;
            Time.fixedDeltaTime = 0.03F * Time.timeScale;
            Time.maximumDeltaTime = 0.03F;
            Destroy(this.gameObject);
        

    }



    private void SlowMotion(bool on)
    {       
        if (on == true)
            Time.timeScale = 0.003F;
        else
            Time.timeScale = 1.0F;
        Time.fixedDeltaTime = 0.01F * Time.timeScale;
    }
  


}
