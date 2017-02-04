#include "stdafx.h"
#include "CursesHelper.h"

int init_pairs() {
	short pair = 1;
	for (int bg = 0; bg < COLORS; bg++) {
		for (int fg = 0; fg < COLORS && pair < COLOR_PAIRS; fg++) {
			int status = init_pair(pair++, fg, bg);
			if (status == ERR) {
				return ERR;
			}
		}
	}

	return OK;
}

chtype color_pair(short fg, short bg) {
	return COLOR_PAIR(1 + bg * COLORS + fg);
}

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
	init_pairs();
}

chtype ToChType(TerminalPixel^ p) {
	return p->ch | color_pair(p->fg, p->bg);
}