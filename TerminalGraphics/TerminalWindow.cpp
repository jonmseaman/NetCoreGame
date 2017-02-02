#include "TerminalWindow.h"



TerminalWindow::TerminalWindow() {

}

#pragma region EditCh

void TerminalWindow::SetBg(short col, int x, int y) {
	throw gcnew System::NotImplementedException();
}

void TerminalWindow::SetFg(short col, int x, int y) {
	throw gcnew System::NotImplementedException();
}

void TerminalWindow::SetCh(int ch, int x, int y) {
	throw gcnew System::NotImplementedException();
}

short TerminalWindow::GetBg(int x, int y) {
	return 0;
}

short TerminalWindow::GetFg(int x, int y) {
	return 0;
}

int TerminalWindow::GetCh(int x, int y) {
	return 0;
}
#pragma endregion

void TerminalWindow::Render() {
	throw gcnew System::NotImplementedException();
}
