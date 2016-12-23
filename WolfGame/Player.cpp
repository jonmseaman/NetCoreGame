#include "stdafx.h"
#include "Player.h"
#include "Components/PlayerInputComponent.h"

Player::Player() {
	this->Input = gcnew PlayerInputComponent();
}
