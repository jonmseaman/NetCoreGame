#pragma once
using namespace WolfEngine;
using namespace WolfEngine::Entity;

ref class GameLoop : public WolfEngine::Game  {

public:
	virtual void ProcessUserInput() override;
	virtual void Render(System::TimeSpan dt) override;
};
