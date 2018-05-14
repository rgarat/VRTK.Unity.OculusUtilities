﻿namespace VRTK.OculusUtilities.Input
{
    using UnityEngine;
    using VRTK.Core.Action;

    /// <summary>
    /// The OculusTouchAction listens for the specified touch state and emits the appropriate action.
    /// </summary>
    public class OculusTouchAction : BooleanAction, IOculusInputControllable
    {
        [Tooltip("The controller to listen for the state change on.")]
        public OVRInput.Controller controller = OVRInput.Controller.Active;
        [Tooltip("The touch to listen for state changes on.")]
        public OVRInput.Touch touch;

        /// <summary>
        /// Controller is the implementation of the interface to access the inherited `controller` field.
        /// </summary>
        public OVRInput.Controller Controller
        {
            get { return controller; }
            set { controller = value; }
        }

        protected virtual void Update()
        {
            Value = OVRInput.Get(touch, controller);
            if (OVRInput.GetDown(touch, controller))
            {
                OnActivated(true);
            }

            if (HasChanged())
            {
                OnChanged(Value);
            }

            if (OVRInput.GetUp(touch, controller))
            {
                OnDeactivated(false);
            }
            previousValue = Value;
        }
    }
}