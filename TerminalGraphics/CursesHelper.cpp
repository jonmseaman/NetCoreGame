#include "CursesHelper.h"

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
	// FIXME: TerminalGraphics::init_pairs();
}