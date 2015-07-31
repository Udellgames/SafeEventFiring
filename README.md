# SafeEventFiring ![SafeEventFiring project build status](https://travis-ci.org/Udellgames/SafeEventFiring.svg?branch=master) ![SafeEventFiring NuGet package version](https://img.shields.io/nuget/v/SafeEventFiring.svg)

Extension methods that provide a simple, thread-safe mechanism for firing events.

This repository is automatically built against the following versions of Mono:
  - beta
  - latest
  - 3.10.0
  - 3.8.0
  
Additionally, the solution was written targeting .NET 3.5. It should work with any version higher than or equal to 3.5, but cannot currently be continuously tested against .NET.
  
Any versions before Mono 3.8.0 are not supported. Nightly / Alpha builds of Mono are not supported, but should work.

# Usage
There are two extension methods, `Fire(object, EventArgs)` and `Fire<T>(object, T)`.

If your event is of type:

* `EventHandler`? Use `Fire(object, EventArgs)`
* `EventHandler<T>`? Use `Fire<T>(object, T)`

Each method takes a reference to the calling instance and an `EventArgs` instance, or subclass of `EventArgs` in the case of `Fire<T>()`.

# Notes
Currently SafeEventFirer does not support events of a type that does not inherit from `EventHandler`. Support for the awkward `PropertyChangedEventHandler` will be coming soon.