#include "stdafx.h"
#include "CreatureGraphicsComponent.h"
#include "SquareLevelGraphicsComponent.h"
#include "../Terminal/CursesHelper.h"

using namespace WolfEngine::Entity;
using namespace WolfEngine::Level;

SquareLevelGraphicsComponent::SquareLevelGraphicsComponent(_win* scr) {
	win = scr;
	CreatureGraphicsComponent::setRenderWindow(scr);

	repChars = gcnew array<chtype>(2);
	init_pair(1, COLOR_BLUE, COLOR_GREEN);
	repChars[0] = ' ' | color_pair(COLOR_BLUE, COLOR_GREEN);
	repChars[1] = '#';
}

SquareLevelGraphicsComponent::~SquareLevelGraphicsComponent() {
	delwin(win);
}

void SquareLevelGraphicsComponent::Update(ILevel^ l) {
	SquareLevel^ level = (SquareLevel^)l;

	// Default origin when there is no focus.
	if (Focus == nullptr) {
		origin = Location(0, level->LevelWidth - 1);
		return;
	}

	Location loc = Focus->Location;

	// If the GameObject would be out of view, adjust the view;
	Location br = Location(origin.X + win->_maxx, origin.Y - win->_maxy);
	bool onScreen = origin.X <= loc.X && loc.X <= br.X
		&& br.Y <= loc.Y && loc.Y <= origin.Y;
	// Shift view to focus
	if (!onScreen) {
		origin = shiftFocus(level, win, origin, loc);
	}

	// Set the origin location so creatures know where to render.
	CreatureGraphicsComponent::setOrigLocation(origin);
}

void SquareLevelGraphicsComponent::Render(ILevel^ l) {
	SquareLevel^ level = (SquareLevel^)l;

	// Print Level
	wmove(win, 0, 0);
	int width = level->LevelWidth;
	int scry = 0, scrx = 0; // Coords on screen.
	for (int y = origin.Y; y >= 0 && win->_maxy >= scry; y--, scry++) {
		wmove(win, scry, 0);
		scrx = 0;
		for (int x = origin.X; x < width && scrx <= win->_maxx; x++, scrx++) {
			int tileNum = level->GetTile(x, y).TileNum;
			waddch(win, repChars[tileNum]);
		}
	}
}

Location SquareLevelGraphicsComponent::shiftFocus(SquareLevel^ level, _win* window, Location origin, Location focus) {
	Location br = Location(origin.X + window->_maxx - 1, origin.Y - window->_maxy + 1);

	int xshift = window->_maxx / 3;
	int yshift = window->_maxy / 3;

	if (focus.X < origin.X) {
		origin.X -= xshift;
	} else if (br.X < focus.X) {
		origin.X += xshift;
	} else if (focus.Y < br.Y) {
		origin.Y -= yshift;
	} else if (origin.Y < focus.Y) {
		origin.Y += yshift;
	}

	// Make sure x coordinate is acceptable.
	int minx = 0,
		maxx = __max(level->LevelWidth - win->_maxx, 0);
	if (origin.X < minx) {
		origin.X = minx;
	} else if (origin.X > maxx) {
		origin.X = maxx;
	}

	// Make sure y coordinate is acceptable.
	int miny = __min(level->LevelWidth - 1, win->_maxy - 1),
		maxy = level->LevelWidth - 1;
	if (origin.Y < miny) {
		origin.Y = miny;
	} else if (origin.Y > maxy) {
		origin.Y = maxy;
	}

	return origin;
}