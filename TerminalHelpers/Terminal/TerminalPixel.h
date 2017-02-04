#pragma once

ref struct TerminalPixel {
public:
	TerminalPixel() {
		fg = COLOR_WHITE; bg = COLOR_BLACK; ch = ' ';
	}
	short fg;
	short bg;
	char32_t ch;
};
