#pragma once

ref class SquareLevelGraphicsComponent : WolfEngine::Level::ILevelGraphicsComponent {
public:
	virtual void Update(WolfEngine::Level::ILevel^);
	virtual void Render(WolfEngine::Level::ILevel^);
};
