#pragma once
#include "Player.h"

using namespace WolfEngine::Entiity;

ref class PlayerInputComponent :
	public IInputComponent {
public:
	PlayerInputComponent();

	virtual void Update(Creature^ c);
};

