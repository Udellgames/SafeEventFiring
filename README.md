# SafeEventFiring
Extension methods that provide a simple, thread-safe method for firing events.

# Usage
There are two extension methods, Fire() and Fire\<T\>().

If your event is of type:

* EventHandler? Use Fire()
* EventHandler\<T\>? Use Fire\<T\>()

Each method takes a reference to the calling instance and an EventArgs instance, or subclass of EventArgs in the case of Fire\<T\>().

# Notes
Currently SafeEventFirer does not support events of a type that does not inherit from EventHandler. Support for the awkward PropertyChangedEventHandler will be coming soon.