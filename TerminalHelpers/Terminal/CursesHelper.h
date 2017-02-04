#pragma once
#include <curses.h>
#include "TerminalPixel.h"

int init_pairs();

chtype color_pair(short fg, short bg);

void setupCurses();

chtype ToChType(TerminalPixel^);