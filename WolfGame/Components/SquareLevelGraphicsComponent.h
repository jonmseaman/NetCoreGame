#pragma once

// Curses WINDOW declaration
struct _win;

ref class SquareLevelGraphicsComponent : WolfEngine::Level::ILevelGraphicsComponent {
public:
	// TODO: Screen on which to render the component.
	SquareLevelGraphicsComponent(_win*);
	~SquareLevelGraphicsComponent();

	// Implementing ILevelGraphicsComponent
	virtual void Update(WolfEngine::Level::ILevel^);
	virtual void Render(WolfEngine::Level::ILevel^);

private:
	// Window which the level will be rendered on.
	_win* win;
};
