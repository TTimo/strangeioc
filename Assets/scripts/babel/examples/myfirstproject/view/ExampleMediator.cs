/// Example mediator
/// =====================
/// Make your Mediator as thin as possible. Its function is to mediate
/// between view and app. Don't load it up with behavior that belongs in
/// the View (listening to/controlling interface), Commands (business logic),
/// Models (maintaining state) or Services (reaching out for data).

using System;
using UnityEngine;
using babel.extensions.dispatcher.eventdispatcher.impl;
using babel.extensions.mediation.impl;

namespace babel.examples.myfirstproject
{
	public class ExampleMediator : Mediator
	{
		private ExampleView view;
		
		public override void onRegister()
		{
			//It is recommended (though not required) to typecast the
			//injected view to the concrete Type you're using.
			//Remember that the Mediator is tightly coupled to the
			//View (the reverse is not true), so casting it to a
			//concrete Type is entirely acceptable
			view = abstractView as ExampleView;
			
			//Listen to the view for an event
			view.dispatcher.addListener(ExampleView.CLICK_EVENT, onViewClicked);
			
			//Listen to the global event bus for events
			globalDispatcher.addListener(ExampleEvent.SCORE_CHANGE, onScoreChange);
			
			view.init ();
		}
		
		public override void onRemove()
		{
			//Clean up listeners when the view is about to be destroyed
			view.dispatcher.removeListener(ExampleView.CLICK_EVENT, onViewClicked);
			globalDispatcher.removeListener(ExampleEvent.SCORE_CHANGE, onScoreChange);
			Debug.Log("Mediator onRemove");
		}
		
		private void onViewClicked()
		{
			Debug.Log("View click detected");
			globalDispatcher.Dispatch(ExampleEvent.REQUEST_WEB_SERVICE);
		}
		
		private void onScoreChange(object data)
		{
			TmEvent evt = data as TmEvent;
			//float score = (float)evt.data;
			string score = (string)evt.data;
			view.updateScore(score);
		}
	}
}
