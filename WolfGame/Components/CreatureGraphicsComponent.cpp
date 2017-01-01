#include "stdafx.h"
#include "CreatureGraphicsComponent.h"

void CreatureGraphicsComponent::Render(WolfEngine::Entity::Creature^ c) {
	// Get render x, y
	int x = c->Location.X - origin.X;
	int y = origin.Y - c->Location.Y;

	if (0 <= x && x < win->_maxx && 0 <= y && y < win->_maxy) {
		wmove(win, y, x);
		waddch(win, repChar);
	}
}

void CreatureGraphicsComponent::Update(WolfEngine::Entity::Creature^ c) {
	// Nothing to do.
}

void CreatureGraphicsComponent::setRenderWindow(WINDOW* window) {
	win = window;
}

void CreatureGraphicsComponent::setOrigLocation(WolfEngine::Level::Location loc) {
	origin = loc;
}
