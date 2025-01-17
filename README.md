# Godot 4 Multiplayer Template

> As of 14/11/23 I am actively working on this, I **strongly** suggest you try the "develop" branch, it has better comments, clearer and improved logic and better debug information. Once I feel its ready I will merge into the main branch and start working on documentation.

This multiplayer template includes the implementation of:

- Authoritative Server Model
- Client Side Prediction and Reconciliation
- Entity Interpolation
- Clock Synchronization
- A few other multiplayer systems

Most of the code is inside the client/ and server/ folders.

You can use this project to speed up your developing process, it is based on the client/auth-server model.

## Usage
You will need Godot 4.X and C# with at least Net6

## What it is
This example demonstrates how to implement a client-server architecture in Godot using the Godot networking API, this can work as a base for a proper game or just to learn how this techniques can be implemented. I did not use RPC calls, I sent packed bytes manually over the network.

## Video Example
The three windows represent (from left to right) a Client, the Server and a Client. I was simulating a "Ping" of 80ms with a jitter of 20ms, as well as a packet loss of 2%, so pretty rough conditions for a multiplayer game, this is the game experience:

[![Example](https://img.youtube.com/vi/oktiP9nrfIw/0.jpg)](https://www.youtube.com/watch?v=oktiP9nrfIw)

Keep in mind I can't show Client Side Prediction on a video, you will have to download the project yourself.

## FPS Example
If you want to see a working example of how this can be made into a FPS game take a look at [this](https://github.com/grazianobolla/ricepot).

**Contact me on Discord (Raz#4584) I will be happy to help**
