using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class BirdkEntityStp3 : BirdEntityBase3
    {
        [SerializeField] private GameObject disappearBehave;
        [SerializeField] private GameObject midFlayBehave;
        
        private IMidFlyAble iMidFlyAble;
        private IDisapperable iDisapperable;
        
        // public void DisappearBird()
        // {
        //     DisableBehave();
        //     Instantiate(disappearParticle, transform.position, Quaternion.identity);
        //     birdObj.gameObject.SetActive(false);
        // }


        private void Awake()
        {
            iMidFlyAble = midFlayBehave?.GetComponent<IMidFlyAble>();
            iDisapperable = midFlayBehave?.GetComponent<IDisapperable>();
        }


        public override void DisableBehave()
        {
            movementCtrl.DesactivateRb();
        }

        public override void AppearBird()
        {
            birdObj.gameObject.SetActive(true);
        }

    }
