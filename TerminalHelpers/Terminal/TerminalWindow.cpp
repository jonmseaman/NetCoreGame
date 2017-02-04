#include "stdafx.h"
#include "TerminalWindow.h"
#include "CursesHelper.h"

// Helper Functions

void TerminalWindow::CreateNewScreen(int width, int height) {
	Height = height; Width = width;
	pixels = gcnew array<TerminalPixel^>(height * width);
	for (int y = 0; y < Height; y++) {
		for (int x = 0; x < Width; x++) {
			TerminalPixel^ p = gcnew TerminalPixel();
			pixels[Width * y + x] = p;
		}
	}
}

TerminalWindow::TerminalWindow() {
	if (!startedCurses) {
		setupCurses();
		startedCurses = true;
	}

	int height = stdscr->_maxy;
	int width = stdscr->_maxx;
	CreateNewScreen(width, height);
}

#pragma region EditCh

void TerminalWindow::SetBg(short col, int x, int y) {
	pixels[Width * y + x]->bg = col;
}

void TerminalWindow::SetFg(short col, int x, int y) {
	pixels[Width * y + x]->fg = col;
}

void TerminalWindow::SetCh(int ch, int x, int y) {
	pixels[Width * y + x]->ch = ch;
}

short TerminalWindow::GetBg(int x, int y) {
	throw gcnew System::NotFiniteNumberException();
}

short TerminalWindow::GetFg(int x, int y) {
	throw gcnew System::NotFiniteNumberException();
}

int TerminalWindow::GetCh(int x, int y) {
	throw gcnew System::NotFiniteNumberException();
}
#pragma endregion

void TerminalWindow::Render() {
	for (int y = 0; y < Height; y++) {
		for (int x = 0; x < Width; x++) {
			chtype ch = ToChType(pixels[Width * y + x]);
			wmove(stdscr, y, x);
			waddch(stdscr, ch);
		}
	}
	wrefresh(stdscr);
}
