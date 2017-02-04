#include "stdafx.h"
#include "GameController.h"

/**
 * Processes input related to game menus.
 */
void GameController::ProcessUserInput() {
	int input = getch();
	switch (input) {
		case ERR:
			break;
		case 27: // ESC
			system("Pause");
			clear();
			break;
		case ALT_X:
			exit(1);
			break;
		default:
			// Don't want to remove char if it cannot be processed here.
			ungetch(input);
			break;
	}
}
