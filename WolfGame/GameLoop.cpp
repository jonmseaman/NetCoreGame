#include "stdafx.h"
#include "Components/SharedGraphicsData.h"
#include "GameLoop.h"

void GameLoop::Loop()
{
	using namespace std;
	using namespace std::chrono;

	Running = true;

	// Times for managing game loop.
	time_point<system_clock> previous = system_clock::now();
	time_point<system_clock> current = system_clock::now();
	duration<double> elapsed = duration<double>(0.0);
	duration<double> lag = duration<double>(0);

	duration<double> timePerUpdate = milliseconds(20);

	while (Running) {
		current = system_clock::now();
		elapsed = current - previous;
		previous = current;
		lag += elapsed;

		processInput();

		while (lag >= timePerUpdate) {
			Focus->Update();
			lag -= timePerUpdate;
		}

		render();

		// Sleep until next time to update.
		elapsed = system_clock::now() - previous;
		double ms = (timePerUpdate - elapsed).count() * 1000.0;
		int msUntilUpdate = (int)ms;

		if (msUntilUpdate > 0) {
			System::Threading::Thread::Sleep(msUntilUpdate);
		}
	}
}

void GameLoop::processInput() {
	int input = getch();
	switch (input) {
		case ERR:
			break;
		case 27: // ESC
			system("Pause");
			clear();
			break;
		case ALT_X:
			Running = false;
			break;
		default:
			// Don't want to remove char if it cannot be processed here.
			ungetch(input);
			break;
	}
}

void GameLoop::render()
{
	using namespace std::chrono;

	move(0, 0);
	printw("Time: ");
	time_t time = system_clock::to_time_t(system_clock::now());
	printw(ctime(&time));

	Focus->Render();
	
	// Refresh the window
	SharedGraphicsData::refresh();
	
}