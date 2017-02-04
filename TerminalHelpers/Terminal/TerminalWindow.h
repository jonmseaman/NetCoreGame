#pragma once
#include "TerminalPixel.h"

public ref class TerminalWindow : public WolfEngine::Graphics::ITermWindow {
private:
	static bool startedCurses = false;
	array<TerminalPixel^>^ pixels;
	void CreateNewScreen(int width, int height);
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

