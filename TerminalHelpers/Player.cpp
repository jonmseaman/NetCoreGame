#include "stdafx.h"
#include "Player.h"
#include "Components/CreatureGraphicsComponent.h"
#include "Components/PlayerInputComponent.h"

Player::Player() {
	this->Input = gcnew PlayerInputComponent();
	this->Graphics = gcnew CreatureGraphicsComponent();
}
