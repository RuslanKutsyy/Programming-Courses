package com.v2lab.minesweeper.appdata;

public class GameProcessor {
    private Game game;
    private Runner runner;

    public GameProcessor() {
    }

    public void Initiate(){
        this.game = new Game();
        this.runner = new Runner(this.game);
        this.runner.Run();
    }
}
