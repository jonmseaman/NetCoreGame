// WolfGame.cpp : main project file.

#include "stdafx.h"
#include "Player.h"

using namespace System;

void render() {
	// TODO: Implement render()
	using namespace std;
	using namespace std::chrono;
	cout << "Time: " << system_clock::to_time_t(system_clock::now()) << endl;
}

void processInput() {
	// TODO: Implement processInput()
}


int main() {
	using namespace std;
	using namespace std::chrono;

	using namespace WolfEngine::Level;
	using namespace WolfEngine::Entiity;

	// Entity being updated
	auto entity = gcnew SquareLevel(5);
	entity->Add(Location(2, 2), gcnew Player());
	
	
	
	// Times for managing game loop.
	time_point<system_clock> previous = system_clock::now();
	time_point<system_clock> current = system_clock::now();
	duration<double> elapsed = duration<double>(0.0);
	duration<double> lag = duration<double>(0);

	duration<double> timePerUpdate = milliseconds(40);

	while (true) {
		current = system_clock::now();
		elapsed = current - previous;
		previous = current;
		lag += elapsed;

		processInput();

		while (lag >= timePerUpdate) {
			entity->Update();
			lag -= timePerUpdate;
		}

		render();

		elapsed = system_clock::now() - previous;
		double ms = (timePerUpdate - elapsed).count() * 1000.0;
		int msUntilUpdate = (int)ms;

		if (msUntilUpdate > 0) {
			System::Threading::Thread::Sleep(msUntilUpdate);
		}
	}
}
