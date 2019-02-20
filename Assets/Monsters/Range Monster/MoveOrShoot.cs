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

    //================================================

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
        IsBouging = false;
        compteur = 0;
        CbBouging = 0;
    }

    //=================================================

    //juste une valeur absolue, parcque c'est chouette
    float abs(float x)
    {
        if (x < 0)
            return -x;
        return x;
    }

    //=================================================

        //Movement sera appelé au debut du mouvement pour actualiser la direction
    void Movement()
    {
        //On prend la localisation du player et du monstre
        Vector3 knight = GameObject.FindGameObjectWithTag("KnightPlayer").transform.position;
        Vector3 monster = body.transform.position;
        int random = Random.Range(0, 10);

        //on prend l'axe la plus éloignée
        if ( abs(monster.z) - abs(knight.z) < abs(monster.x) - abs(knight.x))
        {
            if (random >= 6) // 1/2 d'aller dans le sens opposé
                mouvement = new Vector3(0, 0, -MovementSpeed);
            else
                mouvement = new Vector3(0, 0, MovementSpeed);
        }
        else
        {
            if (random >= 6)
                mouvement = new Vector3(-MovementSpeed, 0, 0);
            else
                mouvement = new Vector3(MovementSpeed, 0, 0);
        }

    }

    //=================================================

    //Shoot sera appelé à chaque fois qu'un projectile est tiré
    void Shoot()
    {
        Debug.Log("Je tiiiire");
    }

    //=================================================

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
                    //Sinon on incrémente le bouging
                    CbBouging += 1;

                    //On bouge
                    body.AddForce(mouvement);
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

                    //on actualise la direction
                    Movement();
                }
                else
                {
                    //... que de tirer
                    Shoot();
                }
            }
        }
    }
}
