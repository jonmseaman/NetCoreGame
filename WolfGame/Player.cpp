#include "stdafx.h"
#include "Player.h"
#include "PlayerInputComponent.h"

Player::Player() {
	this->Input = gcnew PlayerInputComponent();
}
