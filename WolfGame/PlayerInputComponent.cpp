#include "stdafx.h"
#include "PlayerInputComponent.h"
#include <curses.h>

using namespace WolfEngine::Entiity;
using namespace WolfEngine::Level;

PlayerInputComponent::PlayerInputComponent() {}

void PlayerInputComponent::Update(Creature^ c) {
	
	int input = getch();
	switch (input) {
		case 'W':
		case 'w':
			c->Move(Direction::North);
			break;
		case 'A':
		case 'a':
			c->Move(Direction::West);
			break;
		case 'S':
		case 's':
			c->Move(Direction::South);
			break;
		case 'D':
		case 'd':
			c->Move(Direction::East);
			break;
		case ERR:
		default:
			break;
	}
}
