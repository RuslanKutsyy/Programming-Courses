package com.v2lab.minesweeper.appdata;

import java.util.ArrayList;

public class Game {
    public String[][] board;
    public boolean isActive = false;
    public boolean isWon = false;
    public boolean isLost = false;
    public ArrayList<String> minesCoordinates;
    public int genTileCount;

    public Game() {
        this.minesCoordinates = new ArrayList<String>();
    }

    public void setBoard(int type) {
        this.board = new String[type][type];
    }
}
