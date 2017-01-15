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
	 * OrigLocation is the Location the Creature would have to be at to be
	 * rendered at the top left of the window.
	 */
	static void setOrigLocation(WolfEngine::Level::Location);

	short color();
	char repChar();

private:
	char _repChar = 'C';
	short _color = COLOR_YELLOW;

	/*
	 * The window that creatures will be rendered in.
	 */
	static _win* win;

	/*
	* The origin is the Location the Creature would have to be at to be
	* rendered at the top left of the window.
	*/
	static WolfEngine::Level::Location origin;
};
