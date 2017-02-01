#include "TerminalWindow.h"



TerminalWindow::TerminalWindow() {

}

#pragma region EditCh

void TerminalWindow::setbg(short col) {
	throw gcnew System::NotImplementedException();
}

void TerminalWindow::setfg(short col) {
	throw gcnew System::NotImplementedException();
}

void TerminalWindow::setch(int ch) {
	throw gcnew System::NotImplementedException();
}

short TerminalWindow::getbg(int x, int y) {
	return 0;
}

short TerminalWindow::getfg(int x, int y) {
	return 0;
}

int TerminalWindow::getch(int x, int y) {
	return 0;
}
#pragma endregion

void TerminalWindow::Render() {
	throw gcnew System::NotImplementedException();
}
