using UnityEngine;

public class GunScript : MonoBehaviour
{

[SerializeField] public float _Damage;
[SerializeField] public float _Range;
[SerializeField] public float _FireRate;
[SerializeField] public float _BulletForce;
Collider _WeaponCollider;
private Rigidbody rb;
public float _FireCooldown = 0;
public Camera FpsCam;
public ParticleSystem _MuzzleFlash;
public GameObject _BulletImpact;
private bool isUsed;
private bool isDropped;
public Transform _GunType;

public Transform _FirePoint;
public GameObject _BulletObj;


    // Start is called before the first frame update

    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        _WeaponCollider = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        isUsed = transform.parent != null;
        if(isUsed)
        {
        isDropped = false;
        _WeaponCollider.enabled =false;
        rb.isKinematic =true;
        ShotInput();
        }
        else{
        isDropped = true;
        rb.isKinematic = false;
        _WeaponCollider.enabled =true;
        }
    }

    protected virtual void ShotInput(){
        //Input Shot
    if(Input.GetButtonDown("Fire1")){
            Shoot();
        }
    }

    protected virtual void Shoot(){
        //Play muzzle flash when get input
        _MuzzleFlash.Play();

        //Check hit object
       RaycastHit Hit;
       if(Physics.Raycast(FpsCam.transform.position,FpsCam.transform.forward,out Hit,_Range)){
        Debug.Log(Hit.transform.name);
        GameObject ImpactGO =  Instantiate(_BulletImpact,Hit.point,Quaternion.LookRotation(Hit.normal));
        Destroy(ImpactGO,0.5f);

        if(Hit.transform.tag == "box"){
            ObstacleScript _Obstacle = Hit.transform.GetComponent<ObstacleScript>();
            if(_Obstacle != null){
                _Obstacle.Damaged(_Damage);
            }
            if(Hit.rigidbody != null){
                Hit.rigidbody.AddForce(-Hit.normal * _BulletForce);
            }
        }
       }

      


    }

    void OnCollisionEnter(Collision other) {
    if(isDropped){
        if(other.gameObject.CompareTag("Player")){
            if(_GunType.transform.childCount < 1 ){
                Debug.Log("OH thats a body!");
                findParent();
            }
        }
    }
}


    void findParent(){
        transform.SetParent(_GunType);
        isDropped = false;
    }
}
