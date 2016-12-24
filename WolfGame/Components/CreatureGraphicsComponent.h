#pragma once

// Curses WINDOW declaration.
struct _win;

ref class CreatureGraphicsComponent : WolfEngine::Entity::ICreatureGraphicsComponent {
public:
	virtual void Render(WolfEngine::Entity::Creature^);
	virtual void Update(WolfEngine::Entity::Creature^);

	/*
	 * Sets what curses window the creatures will be rendered in.
	 */
	static void setRenderWindow(_win*);

	/*
	 * OrigLocation is the Location that corresponds to (0, 0) in the window.
	 */
	static void setOrigLocation(WolfEngine::Level::Location);

private:
	char repChar = 'C';

	/*
	 * The window that creatures will be rendered in.
	 */
	static _win* win;

	static WolfEngine::Level::Location origLocation;
};
