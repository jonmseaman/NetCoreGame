﻿#include "stdafx.h"
#include "SharedGraphicsData.h"

std::vector<WINDOW*> SharedGraphicsData::windows = std::vector<WINDOW*>();

int SharedGraphicsData::refresh() {
	bool failed = false;

	for (auto window : windows) {
		failed = OK == wrefresh(window);
	}

	return failed ? ERR : OK;
}

void SharedGraphicsData::addWin(WINDOW* window) {
	windows.push_back(window);
}

bool SharedGraphicsData::removeWin(WINDOW* window) {
	bool found = false;

	for (int i = 0; i < windows.size(); i++) {
		// If the windows is found, remove it while not leaving a nullptr.
		if (windows[i] == window) {
			found = true;
			windows[i] = windows[windows.size() - 1];
			windows.pop_back();
		}
	}

	return found;
}