#pragma once
public ref class GameController : public WolfEngine::Controller::IController {
public:
	virtual void ProcessUserInput(void);
};