# Using GDScript because there is no good example of the C# version of this code
# Used docs: https://docs.godotengine.org/en/stable/classes/class_websocketpeer.html

extends Node2D

signal frame(data: String)

var socket = WebSocketPeer.new()

func _ready():
	socket.connect_to_url("ws://localhost:1337")

func _process(_delta):
	socket.poll()
	var state = socket.get_ready_state()
	if state == WebSocketPeer.STATE_OPEN:
		while socket.get_available_packet_count():
			frame.emit(socket.get_packet().get_string_from_utf8())
	elif state == WebSocketPeer.STATE_CLOSING:
		pass
	elif state == WebSocketPeer.STATE_CLOSED:
		var code = socket.get_close_code()
		var reason = socket.get_close_reason()
		print("WebSocket closed with code: %d, reason %s. Clean: %s" % [code, reason, code != -1])
		
		set_process(false)
