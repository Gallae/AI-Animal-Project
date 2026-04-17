using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class WaddleAT : ActionTask {

		public float waddleTimer;
		float waddleDelay =2;
		public BBParameter<GameObject> turtleParent;
        public BBParameter<GameObject> turtleBody;
		public BBParameter<float> hydration;
        public BBParameter<float> fear;
        public BBParameter<float> cleanliness;
		public BBParameter<float> hunger;
        public BBParameter<bool> inWater;
		public BBParameter<bool> isDiving;
        bool steppedLeft = false;

		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit() {
			hydration.value = Random.Range(70f, 100f);
			fear.value = Random.Range(0f, 30f);
			cleanliness.value = Random.Range(70f, 100f);
			inWater.value = false;
			isDiving.value = false;
            return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
			waddleTimer = Random.Range(6f, 10f);
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			hydration.value -= Time.deltaTime * 0.5f;
			fear.value += Time.deltaTime * 0.2f;
			cleanliness.value -= Time.deltaTime * 0.3f;
            waddleTimer -= Time.deltaTime;
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