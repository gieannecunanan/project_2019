using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing; 
using System.Linq;
using System.Text;
using System.Threading.Task;
using System.Windows.Forms;

namespace SnakeGame
{
	public partial class Form1 : Form 
	{ 
		private List<Circle> Snake = new List<Circle>(); // creating a list array for the snake
		private Circle food = new Circle(); // creating a single Circle class called food

		Public Form1()
		{
			IninitalizeComponent();

			new Settings(); // linking the settings Class to this Form

gameTimer.Interval = 1000 / Settings.Speed; // Changing the game time to settings speed 
gameTimer.Tick += updateScreen; // linking a updateScreen function to the timer
gameTimer.Start(); // starting the timer

startGame(); // running the start game function

}

private void updateScreen(object sender, EventArgs e)
{
	// this is the Timers update screen function. 
	// each tick will run this function

	if (Setting.GameOver == true)
	{ 

		// if the game over is true and player presses enter
		// we run the start game function
	
		if (Input.keyPress(Keys.enter))
		{
			startGame();
		}
	}
	else
	{
		// if the game is not over then the following commands will be executed 

		// below the actions will prove the keys being pressed by the player
		// and move accordingly

		if (Input.KeyPress(Keys.Right) && Settings.direction != Direction.Left)
		{
			Settings.direction = Directions.Right;
		}
		else if (Input.KeyPress(Keys.left) && Settings.direction != Directions.Right)
		{
			Settings.direction = Directions.Left;
		}
		else if (Input.KeyPress(Keys.Up) && Settings.directions != Directions.Down)
		{
			Settings.direction = Directions.Up;
		}
else if (Input.KeyPress(Keys.Down) && Settings.directions != Directions.Up)
		{
		Settings.direction = Directions.Down;
		}

		movePlanet(); // run move player function
} 

pbCanvas.Invalidate(); // refresh the picture box and update the graphics on it

}

private void movePlayer()
{
		// the main loop for the snake head and parts
		for (int i = Snake.Count - 1; i >= 0; i --)
		{
			// if the snake head is active
			if (i == 0)
			{
				// move the rest of the body according to which way the head is moving 
				switch (Setting.direction)
				{
					case Directions.Right:
						Snake[i].X++;
						break;
					case Directions.Left:
						Snake[i].X--;
						break;
					case Directions.Up:
						Snake[i].Y--;
						break;
					case Directions.Down:
						Snake[i].Y++;
						break;
				}
	
				// restrict the snake from leaving the canvas 
				int maxXpos = pbCanvas.Size.Width / Settings.Width;
				int maxXpos = pbCanvas.Size.Heigtht / Settings.Height;

				if (
					Snake[i].X < 0 || Snake[i].Y < 0 ||
					Snake[i].x > maxXpos || Snake[i].Y > maxYpos
				   )
				{ 
					// end the game is snake either reaches edge of the canvas 

					die();
				}

			// detect collision with the body 
			// this loop will check if the snake had a collision with other body parts
			for (int j = 1; j < Snake.count; j++)
			{
				if (Snake[i].X == Snake[j].X && Snake[i].Y == Snake[j].Y)
				{
					// if so we run the die function 
					die();
				}
			}
				
			// detect collision between snake head and food
			if (Snake[0].XX == food.X && Snake[0].Y == food.Y)
			{
				// if so we run the eat function
				eat();
			}
		}
		else 
		{ 
			// if there are no collisions then we continue moving the snake and its parts
			Snake[i].X = Snake[i - 1].X;
			Snake[i].Y = Snake[i - 1].Y;
		}
	}
}

private void keyisdown(object sender, KeyEventArgs e)
{
	// the key is down event will trigger the change state from the Input class
	Input.changeState(e.KeyCode, true);
}

private void keyisup(object sender, KeyEventArgs e)
{ 
	// the key is up event will trigger the change state from the Input class
	Input.changestate(e.Keycode, false);
}

private void keyisright(object sender, KeyEventArgs e) 
{
	// key is right event will trigger the change state from the Input class	
	Input.changestate(e.Keycode, true);
}

private void keyisleft(object sender, KeyEventArgs e)
	// key is left event will trigger the change state from the Input class
	Input.changestate(e.Keycode, left); 
}
