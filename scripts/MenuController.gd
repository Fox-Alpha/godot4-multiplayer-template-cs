extends Node3D

var _server_scene = preload("res://scenes/Server.tscn")
var _client_scene = preload("res://scenes/Client.tscn")

@onready var startbuttons: Control = %Buttons
#@onready var buttons := $Buttons

func _on_button_pressed(host:bool):
	var title : String = "";

	if host:
		$Control/Label.text = "Server Side"
		self.add_child(_server_scene.instantiate())
		title = "Dedicated Server"
	else:
		$Control/Label.text = "Client Side"
		self.add_child(_client_scene.instantiate())
		title = "Client"

	startbuttons.queue_free()
	DisplayServer.window_set_title(title)
