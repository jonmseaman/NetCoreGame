#include "stdafx.h"
#include "SquareLevelGraphicsComponent.h"

using namespace WolfEngine::Level;

SquareLevelGraphicsComponent::SquareLevelGraphicsComponent(_win* scr)
{
	win = scr;
}

SquareLevelGraphicsComponent::~SquareLevelGraphicsComponent()
{
	delwin(win);
}

void SquareLevelGraphicsComponent::Update(ILevel^ l) {
	// TODO: Implement this.
}

void SquareLevelGraphicsComponent::Render(ILevel^ l) {
	SquareLevel^ level = (SquareLevel^)l;

	// Print Level
	wmove(win, 0, 0);
	for (int y = 0; y < level->LevelWidth; y++) {
		wprintw(win, "|");
		for (int x = 0; x < level->LevelWidth; x++) {

			//int tileNum = 'a' + level->default[x, y].TileNum;
			int tileNum = 'a';
			char data[2];
			data[0] = 'a' + level->GetTile(x, y).TileNum;
			data[1] = '\0';
			wprintw(win, data);
		}

		wprintw(win, "|\n");
	}
	wrefresh(win);
}