using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OrbOfEverything.Engine
{

    /// <summary>
    /// This is the basic protocol for participating in frame update callbacks of OOEEngine.
    /// 
    /// You should implement this protocol for observing OOEEngine frame updates.
    /// </summary>
    public interface OOEEngineObserving: IDisposable
    {

        /// <summary>
        /// Indicates whether the observer is observing or paused fixed frame update callback event.
        /// </summary>
        bool IsPaused { get; set; }

        /// <summary>
        /// Called when the engine changed the fps value.
        /// </summary>
        /// <param name="sender">Sender object that sent this message.</param>
        void FPSChanged(OOEEngine sender);

        /// <summary>
        /// OOEEngine calls this method at specific interval.
        /// </summary>
        void FixedUpdate();
    }








    public enum OOEEngineObserverType
    {
        unspecified, animator, physics, custom, graphics
    }
}
