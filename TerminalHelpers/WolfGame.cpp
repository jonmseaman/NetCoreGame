// WolfGame.cpp : main project file.

#include "stdafx.h"
#include "GameLoop.h"
#include "Player.h"
#include "Components/CreatureGraphicsComponent.h"
#include "Components/TerminalGraphics.h"
#include "Components/SquareLevelGraphicsComponent.h"


using namespace System;
using namespace WolfEngine::Level;

void setupCurses() {
	// Setup curses
	initscr();
	cbreak();
	noecho();
	nodelay(stdscr, TRUE);
	nonl();
	intrflush(stdscr, FALSE);
	keypad(stdscr, TRUE);
	curs_set(0); // Invisible cursor

				 // Color
	start_color();
	TerminalGraphics::init_pairs();
}


int main() {
	using namespace std::chrono;

	using namespace WolfEngine::Level;
	using namespace WolfEngine::Entity;

	// Curses is used for user input.
	setupCurses();

	// Entity being updated
	auto level = gcnew SquareLevel(125);

	WINDOW* win = subwin(stdscr, stdscr->_maxy - 2, stdscr->_maxx, 1, 0);
	TerminalGraphics::addWin(win);
	auto graphics = gcnew SquareLevelGraphicsComponent(win);
	auto player = gcnew Player();
	graphics->Focus = player;
	level->Graphics = graphics;
	level->Add(Location(2, 2), player);

	// Prepare game loop
	GameLoop^ loop = gcnew GameLoop();
	loop->Focus = level;

	loop->Loop();

	// Stop curses mode
	endwin();
}
