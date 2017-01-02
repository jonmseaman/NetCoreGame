#pragma once
#include <vector>
// Curses window declaration
struct _win;

/**
 * Holds some graphics data and methods used by multiple GraphicsComponents.
 */
class SharedGraphicsData {
public:
	/**
	 * Refreshes all windows added to SharedGraphicsData.
	 * @return OK if all window refreshes were OK.
	 */
	static int refresh();

	static void addWin(_win*);

	/**
	 * Removes the window from the list.
	 */
	static bool removeWin(_win*);

	/**
	 * Initializes all colors pairs.
	 */
	static int init_pairs();

	/**
	 *
	 */
	static chtype color_pair(short fg, short bg);

private:
	static std::vector<_win*> windows;
};
