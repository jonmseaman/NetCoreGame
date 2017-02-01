#pragma once
#include "TerminalPixel.h"

ref class TerminalWindow :
	public WolfEngine::Graphics::IWindow {
private:

	array<TerminalPixel^>^ pixels;
public:
	TerminalWindow();
	virtual property int Height;
	virtual property int Width;

	void setbg(short col);
	void setfg(short col);
	void setch(int ch);

	short getbg(int x, int y);
	short getfg(int x, int y);
	int getch(int x, int y);

	void Render();
};

