#include "stdafx.h"
#include "CreatureGraphicsComponent.h"

void CreatureGraphicsComponent::Render(WolfEngine::Entity::Creature^ c) {
	// Get render x, y
	int x = c->Location.X - origLocation.X;
	int y = origLocation.Y - c->Location.Y;

	if (0 <= x && 0 <= y && x <= win->_maxx && y <= win->_maxy) {
		wmove(win, y, x);
		wprintw(win, "C");
	}
}

void CreatureGraphicsComponent::Update(WolfEngine::Entity::Creature^ c) {
	// TODO: Implement this.
}

void CreatureGraphicsComponent::setRenderWindow(WINDOW* window) {
	win = window;
}

void CreatureGraphicsComponent::setOrigLocation(WolfEngine::Level::Location loc) {
	origLocation = loc;
}
