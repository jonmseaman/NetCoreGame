#pragma once
#include "TerminalPixel.h"

ref class TerminalWindow : public WolfEngine::Graphics::ITermWindow {
private:

	array<TerminalPixel^>^ pixels;
public:
	TerminalWindow();
	virtual property int Height;
	virtual property int Width;

	void setbg(short col, int x, int y);
	void setfg(short col, int x, int y);
	void setch(int ch, int x, int y);

	short getbg(int x, int y);
	short getfg(int x, int y);
	int getch(int x, int y);

	void Render();
};

