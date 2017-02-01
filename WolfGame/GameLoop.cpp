#include "stdafx.h"
#include "Components/TerminalGraphics.h"
#include "GameLoop.h"

void GameLoop::ProcessUserInput() {
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

void GameLoop::Render(System::TimeSpan dt)
{
	using namespace std::chrono;

	move(0, 0);
	printw("Time: ");
	time_t time = system_clock::to_time_t(system_clock::now());
	printw(ctime(&time));

	Focus->Render();
	
	// Refresh the window
	TerminalGraphics::refresh();
}