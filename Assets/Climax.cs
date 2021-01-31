using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Climax : MonoBehaviour
{
    public float experienceLength;
    public float climaxStartTime;
    bool climaxStarted = false;
    public UnityEvent BeginFadeAway;
    float timer = 0;
    bool TimeUp = false;
    float t;
    public float ExperienceProgress;

    public ParticleSystem[] particleSystems;


   public ParticleSystemForceField climaxField;

    float climaxSpinmax;
    ParticleSystem.MinMaxCurve climaxGravity;
    ParticleSystem.MinMaxCurve climaxSpin;
    ParticleSystem.MinMaxCurve climaxSpinAttraction;
    ParticleSystem.MinMaxCurve climaxY;



    private void Start()
    {
        if (BeginFadeAway == null) 
        {
            BeginFadeAway = new UnityEvent();
        }

        climaxSpin = climaxField.rotationSpeed;
        climaxGravity = climaxField.gravity;
        climaxY = climaxField.directionY;
        climaxSpinAttraction = climaxField.rotationAttraction;


        climaxField.rotationSpeed = new ParticleSystem.MinMaxCurve(0);
        climaxField.gravity = new ParticleSystem.MinMaxCurve(0);
        climaxField.directionY = new ParticleSystem.MinMaxCurve(0);
        climaxField.rotationAttraction = new ParticleSystem.MinMaxCurve(0);    //TODO add attraction lerping.
        

    }
    private void Update()
    {

        if (timer + Time.deltaTime >= climaxStartTime * 60 && timer + Time.deltaTime < experienceLength * 60)
        {
            t = ((timer + Time.deltaTime) - climaxStartTime * 60) / (experienceLength * 60 - climaxStartTime * 60);


            climaxField.rotationSpeed = new ParticleSystem.MinMaxCurve(Mathf.Lerp(0, climaxSpin.constant, t));
            climaxField.gravity = new ParticleSystem.MinMaxCurve(Mathf.Lerp(0, climaxGravity.constant, t));
            climaxField.directionY = new ParticleSystem.MinMaxCurve(Mathf.Lerp(0, climaxY.constant, t));
            climaxField.rotationAttraction = new ParticleSystem.MinMaxCurve(Mathf.Lerp(0, climaxSpinAttraction.constant, t));


            /*foreach (ParticleSystem p in particleSystems)
            {
                var em = p.emission;
                em.enabled = false;

            }*/

        }
        if (timer + Time.deltaTime < experienceLength * 60) 
        {
            timer += Time.deltaTime;
            ExperienceProgress = Mathf.Round((timer / (experienceLength*60) * 100));
        }
        else if(!TimeUp)
        {
            TimeUp = true;
            if (BeginFadeAway != null)
            {
                BeginFadeAway.Invoke();
            }

            foreach (ParticleSystem p in particleSystems)
            {
                var em = p.emission;
                em.enabled = false;

            }
            
        }

    }
}
