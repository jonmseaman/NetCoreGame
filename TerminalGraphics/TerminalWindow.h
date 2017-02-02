#pragma once
#include "TerminalPixel.h"

ref class TerminalWindow : public WolfEngine::Graphics::ITermWindow {
private:

	array<TerminalPixel^>^ pixels;
public:
	TerminalWindow();
	virtual property int Height;
	virtual property int Width;

	virtual void SetBg(short col, int x, int y);
	virtual void SetFg(short col, int x, int y);
	virtual void SetCh(int ch, int x, int y);

	virtual short GetBg(int x, int y);
	virtual short GetFg(int x, int y);
	virtual int GetCh(int x, int y);

	void Render();
};

