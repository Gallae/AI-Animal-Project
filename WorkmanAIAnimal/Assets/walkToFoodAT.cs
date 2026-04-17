using NodeCanvas.Framework;
using ParadoxNotion.Design;
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
            turtleParent.value.transform.LookAt(food.value.transform);
            return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
			EndAction(true);
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
            if (waddleTimer % waddleDelay <= 0.2f)
            {
                takeStep();
            }
            if (waddleTimer <= 0)
            {
                EndAction(true);
            }
        }

		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
        void takeStep()
        {
            Debug.Log("Taking step");
            turtleParent.value.transform.Translate(0.1f, 0, 0);
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