#pragma once

ref class SquareLevelGraphicsComponent : WolfEngine::Level::ILevelGraphicsComponent {
public:
	// TODO: Screen on which to render the component.

	// Implementing ILevelGraphicsComponent
	virtual void Update(WolfEngine::Level::ILevel^);
	virtual void Render(WolfEngine::Level::ILevel^);
};
