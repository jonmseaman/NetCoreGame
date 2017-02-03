#pragma once
#include "../Player.h"

using namespace WolfEngine::Entity;

ref class PlayerInputComponent :
	public IInputComponent {
public:
	PlayerInputComponent();

	virtual void Update(Creature^ c);
};

