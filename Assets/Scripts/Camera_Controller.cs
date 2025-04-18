using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.AI;
public class Camera_Controller : MonoBehaviour
{
    float screenPixEdge = 10f;
    float min = 20f, max = 60f, cameraFOV;
    float moveMin = -100, moveMax = 100;
    Camera sceneCam;
    public LayerMask targetLayer;
    public GameObject endScreen, policeNPC, targetText, incorrectText;
    [Range(0, 10)]
    public float rotateSpeed;
    public NPC_Spawning npc_spawning;
    public Slider zoomSlider;
    public Toggle foundToggle, sObjectiveToggle;
    ScoreCalculator scoreCalc;
    

    void Start(){
        sceneCam = this.gameObject.GetComponent<Camera>();
        scoreCalc = GameObject.Find("Scoring").GetComponent<ScoreCalculator>();
        cameraFOV = 60f;
        zoomSlider.maxValue = cameraFOV;
        
    }
    void Update()
    {   
        //MoveCamera();
        targetPerson();
        if(Input.GetKey(KeyCode.E) && cameraFOV <= max){
            cameraFOV++;
        }
        if(Input.GetKey(KeyCode.Q) && cameraFOV >= min){
            cameraFOV--;
        }
        
        sceneCam.fieldOfView = cameraFOV;
        zoomSlider.value = cameraFOV;
    }

    void targetPerson(){
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = sceneCam.nearClipPlane;
        Ray ray = sceneCam.ScreenPointToRay(mousePos);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, targetLayer)){
            if(Input.GetButtonDown("Fire1")){
                if(hit.collider.gameObject.GetComponent<NPC_Behaviour>() != null){
                    if(hit.collider.gameObject.GetComponent<NPC_Behaviour>().npcInfoSO.isTarget == true){
                        //Destroy(hit.collider.gameObject);
                        //do screen effect?
                        hit.collider.gameObject.GetComponent<NavMeshAgent>().speed = 0;
                        hit.collider.gameObject.GetComponent<NPC_Behaviour>().anims.SetBool("isCaught", true);
                        policeNPC.GetComponent<NavMeshAgent>().SetDestination(hit.collider.gameObject.transform.position);
                        GameObject textClone1 = Instantiate(targetText, hit.collider.gameObject.transform);
                        textClone1.transform.LookAt(this.gameObject.transform);
                        Destroy(textClone1, 1f);
                        foundToggle.GetComponent<Toggle>().isOn = true;
                        //play sound
                        scoreCalc.finalScore += 1000;
                        PlayerPrefs.SetInt("TargetFound", 1);

                    }
                    if(hit.collider.gameObject.GetComponent<NPC_Behaviour>().npcInfoSO.isTarget == false){
                        //bad sound effect?
                        scoreCalc.incorrectGuess++;
                        scoreCalc.finalScore -= 100;
                        GameObject textClone2 = Instantiate(incorrectText, hit.collider.gameObject.transform);
                        textClone2.transform.LookAt(this.gameObject.transform);
                        Destroy(textClone2, 1f);
                    }   
                }
                if(hit.collider.gameObject.tag == "OtherTarget"){
                    sObjectiveToggle.GetComponent<Toggle>().isOn = true;
                    Destroy(hit.collider.gameObject);
                    scoreCalc.finalScore += 500;
                    PlayerPrefs.SetInt("WeaponFound", 1);
                }
                
            }
            
        }
    }

    void MoveCamera(){
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");

        moveHorizontal = Mathf.Clamp(moveHorizontal, moveMin, moveMax);
        moveVertical = Mathf.Clamp(moveVertical, moveMin, moveMax);

        Vector3 rotationVector = moveHorizontal * transform.up + moveVertical * transform.forward;

        //sceneCam.transform.localEulerAngles = rotationVector * rotateSpeed;

        transform.Rotate(rotationVector * rotateSpeed * Time.deltaTime);


    }

    
}   
