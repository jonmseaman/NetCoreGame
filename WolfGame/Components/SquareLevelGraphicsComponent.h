#pragma once

// Curses WINDOW declaration
struct _win;

ref class SquareLevelGraphicsComponent : WolfEngine::Level::ILevelGraphicsComponent {
public:
	// When rendering, the level will try to make sure the focus is in view.
	property WolfEngine::Entity::GameObject^ Focus;

	SquareLevelGraphicsComponent(_win*);
	~SquareLevelGraphicsComponent();

	// Implementing ILevelGraphicsComponent
	virtual void Update(WolfEngine::Level::ILevel^);
	virtual void Render(WolfEngine::Level::ILevel^);

private:
	// The location on the level that will be rendered at (0, 0) on screen.
	WolfEngine::Level::Location origin;
	
	// Window which the level will be rendered on.
	_win* win;
};
