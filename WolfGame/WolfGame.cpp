// WolfGame.cpp : main project file.

#include "stdafx.h"

using namespace System;

void render() {
	// TODO: Implement render()
	using namespace std;
	using namespace std::chrono;
	cout << "Time: " << system_clock::to_time_t(system_clock::now()) << endl;
}

void update() {
	// TODO: Implement update()
}

void processInput() {
	// TODO: Implement processInput()
}


int main(array<System::String ^> ^args) {
	using namespace std;
	using namespace std::chrono;

	time_point<system_clock> previous = system_clock::now();
	time_point<system_clock> current = system_clock::now();
	duration<double> elapsed = duration<double>(0.0);
	duration<double> lag = duration<double>(0);

	duration<double> timePerUpdate = milliseconds(1000);

	while (true) {
		current = system_clock::now();
		elapsed = current - previous;
		previous = current;
		lag += elapsed;

		processInput();

		while (lag >= timePerUpdate) {
			update();
			lag -= timePerUpdate;
		}

		render();

#pragma warning(disable:4244)  
		elapsed = system_clock::now() - previous;
		double ms = (timePerUpdate - elapsed).count() * 1000.0;
		int msUntilUpdate = (int)ms;
#pragma warning(default:4244)  
		if (msUntilUpdate > 0) {
			System::Threading::Thread::Sleep(msUntilUpdate);
		}
	}




}

