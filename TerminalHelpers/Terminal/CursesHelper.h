#pragma once
#include <curses.h>
#include "TerminalPixel.h"

void setupCurses();

chtype ToChType(TerminalPixel^);