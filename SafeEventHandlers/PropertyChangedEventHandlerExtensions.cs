using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

/// <summary>
/// Extension methods for PropertyChangedEventHandlers
/// </summary>
public static class PropertyChangedEventHandlerExtensions
{
    /// <summary>
    /// Raises an event thread-safely if the event has subscribers.
    /// </summary>
    /// <param name="handler"> The event handler to raise. </param>
    /// <param name="sender"> The object that sent this event. </param>
    /// <param name="args"> The event args. </param>
    [SuppressMessage("Microsoft.Design",
        "CA1030:UseEventsWhereAppropriate",
        Justification = "This warning comes up when you use the word `Fire` in a method name. This method specifically raises events, and so does not need changing.")]
    [DebuggerHidden]
    public static void Fire(this PropertyChangedEventHandler handler, object sender, PropertyChangedEventArgs args)
    {
        if (handler != null)
        {
            handler(sender, args);
        }
    }
}