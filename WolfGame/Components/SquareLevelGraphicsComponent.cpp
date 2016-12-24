#include "stdafx.h"
#include "CreatureGraphicsComponent.h"
#include "SquareLevelGraphicsComponent.h"

using namespace WolfEngine::Entity;
using namespace WolfEngine::Level;

SquareLevelGraphicsComponent::SquareLevelGraphicsComponent(_win* scr) {
	win = scr;
	CreatureGraphicsComponent::setRenderWindow(scr);
}

SquareLevelGraphicsComponent::~SquareLevelGraphicsComponent() {
	delwin(win);
}

void SquareLevelGraphicsComponent::Update(ILevel^ l) {
	SquareLevel^ level = (SquareLevel^)l;

	// Set the origin location so creatures know where to render.
	origin = Location(0, level->LevelWidth - 1);
	CreatureGraphicsComponent::setOrigLocation(origin);
	// TODO: For large levels, adjust this according to a 'Focus' Creature (The Player)
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
			waddch(win, '_' + tileNum);
		}
	}
}