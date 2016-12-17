#include "stdafx.h"
#include "PlayerInputComponent.h"
#include <curses.h>

using namespace WolfEngine::Entiity;

PlayerInputComponent::PlayerInputComponent() {
	std::cout << "Setting up curses\n";
}

void PlayerInputComponent::Update(Creature^ c)
{
	// TODO: Implement PlayerInputComponent::Update
	initscr();
	refresh();
	std::cout << "PlayerInputComponent::Update: \n";
	std::cout << (char)getch() << '\n';
}
