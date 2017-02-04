#include "stdafx.h"
#include "Terminal/CursesHelper.h"
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
	throw gcnew System::NotImplementedException();
}