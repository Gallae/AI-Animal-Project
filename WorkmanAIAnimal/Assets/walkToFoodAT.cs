using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class walkToFoodAT : ActionTask {

        public BBParameter<GameObject> food;
        public float waddleTimer;
        float waddleDelay = 2;
        public BBParameter<GameObject> turtleParent;
        public BBParameter<GameObject> turtleBody;
        bool steppedLeft = false;

        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit() {
            return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
            Debug.DrawLine(turtleParent.value.transform.position, food.value.transform.position, Color.red, 5f);
            waddleTimer = UnityEngine.Random.Range(6f, 10f);
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
            //waddleTimer -= Time.deltaTime;
            //if (waddleTimer % waddleDelay <= 0.2f)
            //{
                takeStep();
            //}
        }

		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
        void takeStep()
        {
            turtleParent.value.transform.rotation = Quaternion.LookRotation(food.value.transform.position - turtleParent.value.transform.position);
            Debug.Log("Taking step");
            turtleParent.value.transform.Translate(turtleParent.value.transform.forward * 0.1f);
            if (!steppedLeft)
            {
                turtleBody.value.transform.Rotate(0, -10, 0);
                steppedLeft = true;
                return;
            }
            else
            {
                turtleBody.value.transform.Rotate(0, 10, 0);
                steppedLeft = false;
                return;
            }
        }
    }
}