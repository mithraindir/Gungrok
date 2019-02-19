using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOrShoot : MonoBehaviour
{
    public float MovementSpeed;
    public float ProjectileSpeed;
    public float DureeMovement;
    public float DureeEntreActions;

    Rigidbody body;
    Vector3 mouvement;
    

    //Le compteur permettra de n'effectuer les mouvements qu'au bout d'un laps de temps
    float compteur;

    //Ces infos permettent de bouger pendant un moment (plus long qu'une frame)
    bool IsBouging;
    float CbBouging;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
        IsBouging = false;
        compteur = 0;
        CbBouging = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (compteur != DureeEntreActions && !IsBouging)
            compteur += 1;
        else
        {
            if (IsBouging)
            {
                //Si le monstre est en mouvement
                if (CbBouging == DureeMovement)
                {
                    //Si on a fini de bouger on reset
                    IsBouging = false;
                    CbBouging = 0;
                }
                else
                {
                    //Sinon on bouge
                    CbBouging += 1;
                    Debug.Log("Je Bouuuge");
                }
            }
            else
            {
                //On reset la durée entre actions
                compteur = 0;

                //prend un entier random entre 0 et 9 inclus
                if (Random.Range(0,10) >= 7)
                {
                    //moins de chance de bouger...
                    IsBouging = true;
                }
                else
                {
                    //... que de tirer
                    Debug.Log("Je tiiiire");
                }
            }
        }
    }
}
