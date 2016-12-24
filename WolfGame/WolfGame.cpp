// WolfGame.cpp : main project file.

#include "stdafx.h"
#include "GameLoop.h"
#include "Player.h"
#include "Components/SquareLevelGraphicsComponent.h"

using namespace System;
using namespace WolfEngine::Level;

void setupCurses()
{
	// Setup curses
	initscr();
	cbreak();
	noecho();
	nodelay(stdscr, TRUE);
	nonl();
	intrflush(stdscr, FALSE);
	keypad(stdscr, TRUE);
}

int main() {
	using namespace std::chrono;

	using namespace WolfEngine::Level;
	using namespace WolfEngine::Entity;

	// Curses is used for user input.
	setupCurses();

	// Entity being updated
	auto level = gcnew SquareLevel(25);

	level->Graphics = gcnew SquareLevelGraphicsComponent(newwin(28, 120, 1, 0));
	level->Add(Location(2, 2), gcnew Player());

	// Prepare game loop
	GameLoop^ loop = gcnew GameLoop();
	loop->Focus = level;

	loop->Loop();

	// Stop curses mode
	endwin();
}
