#pragma once
using namespace WolfEngine;
using namespace WolfEngine::Entity;

ref class GameLoop : public IGameLoop {

public:
	property GameObject^ Focus {
		virtual GameObject^ get()
		{
			return _focus;
		}

		virtual void set(GameObject^ val)
		{
			_focus = val;
		}
	}

	property bool Running {

		virtual bool get() {
			return _running;
		}

		virtual void set(bool val) {
			_running = val;
		}
	};

	virtual void Loop();

private:
	bool _running;
	GameObject^ _focus;

	void processInput();
	void render();
};
