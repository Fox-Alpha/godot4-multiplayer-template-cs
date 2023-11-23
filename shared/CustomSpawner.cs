using Godot;
using System;

public partial class CustomSpawner : MultiplayerSpawner
{
    [Export] private PackedScene _playerScene;
    [Export] private PackedScene _serverPlayerScene;
    [Export] private PackedScene _dummyScene;

    public static ClientPlayer LocalPlayer;

    public override void _Ready()
    {
        Callable customSpawnFunctionCallable = new Callable(this, nameof(CustomSpawnFunction));
        this.SpawnFunction = customSpawnFunctionCallable;

        this.SetMultiplayerAuthority(Multiplayer.GetUniqueId());

        var time = Time.GetDatetimeStringFromSystem(false, true);

		GD.Print(time, " : ",
			"MultiplayerSpawner::_Ready(): Callable this.SpawnFunction => :",
			$"{this.GetParent().Name} / ",
			$"{this.SpawnFunction.Method} / ",
			$"{this.SpawnFunction.Target} / ",
			$"{this.SpawnFunction.Target.GetType()} / ",
			$"{this.SpawnFunction.Target.GetClass()}",
			$"{this.SpawnFunction.Target.GetScript()} / "
		);
    }

    private Node CustomSpawnFunction(Variant data)
    {
        int spawnedPlayerID = (int)data;
        int localID = Multiplayer.GetUniqueId();

        GD.Print($">> MultiplayerSpawner::CustomSpawnFunction(): Local UniqueId: ({Multiplayer.GetUniqueId()} / Authority: {GetMultiplayerAuthority()})");

        var time = Time.GetTicksMsec(); // GetDatetimeStringFromSystem(false, true);

        GD.Print(time, 
			": MultiplayerSpawner::_Ready(): Callable this.SpawnFunction => :",
			$"\n\tMultiplayerAuthority of MultiplayerSpawner: {this.GetMultiplayerAuthority()} / ",
			$"\n\tMethodName: {this.SpawnFunction.Method} / ",
			$"\n\tTarget: {this.SpawnFunction.Target} / ",
			$"\n\tGetType(): {this.SpawnFunction.Target.GetType()} / ",
			$"\n\tGetClass(): {this.SpawnFunction.Target.GetClass()}",
			$"\n\tGetScript(): {this.SpawnFunction.Target.GetScript()} / "
		);

        // Server character for simulation
        if (localID == 1)
        {
            GD.Print("Spawned server character");
            ServerPlayer player = _serverPlayerScene.Instantiate() as ServerPlayer;
            player.Name = spawnedPlayerID.ToString();
            player.MultiplayerID = spawnedPlayerID;
            return player;
        }

        // Client player
        if (localID == spawnedPlayerID)
        {
            GD.Print("Spawned client player");
            ClientPlayer player = _playerScene.Instantiate() as ClientPlayer;
            player.Name = spawnedPlayerID.ToString();
            player.SetMultiplayerAuthority(spawnedPlayerID);
            LocalPlayer = player;
            return player;
        }

        // Dummy player
        {
            GD.Print("Spawned dummy");
            Node player = _dummyScene.Instantiate();
            player.Name = spawnedPlayerID.ToString();
            player.SetMultiplayerAuthority(spawnedPlayerID);
            return player;
        }
    }
}
