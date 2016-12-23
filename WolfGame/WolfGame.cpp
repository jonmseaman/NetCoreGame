// WolfGame.cpp : main project file.

#include "stdafx.h"
#include "GameLoop.h"
#include "Player.h"

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

	// Entity being updated
	auto level = gcnew SquareLevel(5);
	level->Add(Location(2, 2), gcnew Player());
	
	// Curses is used for user input.
	setupCurses();

	// Prepare game loop
	GameLoop^ loop = gcnew GameLoop();
	loop->Focus = level;

	loop->Loop();

	// Stop curses mode
	endwin();
}
