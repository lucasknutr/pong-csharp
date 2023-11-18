using Godot;
using System;

public partial class Player : CharacterBody2D
{
	[Export]
	int IdPlayer = 1;
	[Export]
	int Speed = 1000;
	public override void _PhysicsProcess(double delta){
		Movement();
		this.MoveAndCollide(this.Velocity * (float)delta);
	}

	public void Movement(){
		if(Input.IsActionPressed("UP_"+IdPlayer.ToString())){
			this.Velocity = new Vector2(0, -Speed);
		}
		else if(Input.IsActionPressed("DOWN_"+IdPlayer.ToString())){
			this.Velocity = new Vector2(0, Speed);
		}
		else if(Input.IsActionPressed("LEFT_"+IdPlayer.ToString())){
			this.Velocity = new Vector2(-Speed, 0);
		}
		else if(Input.IsActionPressed("RIGHT_"+IdPlayer.ToString())){
			this.Velocity = new Vector2(Speed, 0);
		}
		else{
			this.Velocity = new Vector2(0, 0);
		}
	}
}