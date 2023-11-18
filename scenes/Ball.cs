using Godot;
using System;

public partial class Ball : CharacterBody2D
{
	[Export]
	int Speed = 300;
	Vector2 direction;
	public override void _Ready(){
		direction = new Vector2(0,0);
	}

	public override void _PhysicsProcess(double delta){
		var collision = this.MoveAndCollide(direction * (float)delta);

		// Gets the name of the node that collided with the ball, in this case: "Wall2"
		var isTouchingWall = ((Node)collision.GetCollider()).IsInGroup("walls");
		var isTouchingPlayer = ((Node)collision.GetCollider()).IsInGroup("players");
		// var isTouchingGoal = ((Node)collision.GetCollider()).IsInGroup("goals");
		if(isTouchingPlayer)
		{
			direction.X = direction.X * -1 * 1.1f;
		}
		// else if(isTouchingGoal)
		// {
		// 	direction = new Vector2(-1*Speed, 1*Speed);
		// 	Speed = 300;
		// }
		else if(isTouchingWall)
		{
			direction.Y = direction.Y * -1;
		}
	}

	public void Start(){
		direction = new Vector2(GD.RandRange(-2, 2) * Speed, GD.RandRange(-2, 2) * Speed);
	}
}
