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

void SquareLevelGraphicsComponent::Update(ILevel^ level) {
	// TODO: Implement this.
}

void SquareLevelGraphicsComponent::Render(ILevel^ level) {
	// TODO: Implement this.
}