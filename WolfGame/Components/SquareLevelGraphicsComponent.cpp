#include "stdafx.h"
#include "CreatureGraphicsComponent.h"
#include "SquareLevelGraphicsComponent.h"

using namespace WolfEngine::Level;

SquareLevelGraphicsComponent::SquareLevelGraphicsComponent(_win* scr)
{
	win = scr;
	CreatureGraphicsComponent::setRenderWindow(scr);
}

SquareLevelGraphicsComponent::~SquareLevelGraphicsComponent()
{
	delwin(win);
}

void SquareLevelGraphicsComponent::Update(ILevel^ l) {
	SquareLevel^ level = (SquareLevel^)l;

	// Set the origin location so creatures know where to render.
	CreatureGraphicsComponent::setOrigLocation(Location(0, level->LevelWidth - 1));
	// TODO: For large levels, adjust this according to a 'Focus' Creature (The Player)
}

void SquareLevelGraphicsComponent::Render(ILevel^ l) {
	SquareLevel^ level = (SquareLevel^)l;

	// Print Level
	wmove(win, 0, 0);
	for (int y = 0; y < level->LevelWidth; y++) {
		for (int x = 0; x < level->LevelWidth; x++) {

			//int tileNum = 'a' + level->default[x, y].TileNum;
			int tileNum = 'a';
			char data[2];
			data[0] = 'a' + level->GetTile(x, y).TileNum;
			data[1] = '\0';
			wprintw(win, data);
		}

		wprintw(win, "\n");
	}
}