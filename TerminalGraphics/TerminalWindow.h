#pragma once
ref class TerminalWindow :
	public WolfEngine::Graphics::IWindow {
public:
	TerminalWindow();
	
	virtual property int Height;
	virtual property int Width;
};

