// WolfGame.cpp : main project file.

#include "stdafx.h"
#include "Player.h"

using namespace System;

void render() {
	using namespace std::chrono;
	move(0, 0);
	printw("Time: ");
	time_t time = system_clock::to_time_t(system_clock::now());
	printw(ctime(&time));
	refresh();
}

void processInput() {
	int input = getch();
	switch (input) {
		case ERR:
			break;
		case 27:
			system("Pause");
			clear();
			break;
		default:
			// Don't want to remove char if it cannot be processed here.
			ungetch(input);
			break;
	}
}

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
	auto entity = gcnew SquareLevel(5);
	entity->Add(Location(2, 2), gcnew Player());
	
	// Curses is used for user input.
	setupCurses();
	
	// Times for managing game loop.
	time_point<system_clock> previous = system_clock::now();
	time_point<system_clock> current = system_clock::now();
	duration<double> elapsed = duration<double>(0.0);
	duration<double> lag = duration<double>(0);

	duration<double> timePerUpdate = milliseconds(20);

	while (true) {
		current = system_clock::now();
		elapsed = current - previous;
		previous = current;
		lag += elapsed;

		processInput();

		while (lag >= timePerUpdate) {
			entity->Update();
			lag -= timePerUpdate;
		}

		render();

		// Sleep until next time to update.
		elapsed = system_clock::now() - previous;
		double ms = (timePerUpdate - elapsed).count() * 1000.0;
		int msUntilUpdate = (int)ms;

		if (msUntilUpdate > 0) {
			System::Threading::Thread::Sleep(msUntilUpdate);
		}
	}

	// Stop curses mode
	endwin();
}
