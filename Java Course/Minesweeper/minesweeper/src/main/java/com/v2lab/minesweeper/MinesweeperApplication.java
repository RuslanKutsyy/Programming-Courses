package com.v2lab.minesweeper;

import com.v2lab.minesweeper.appdata.GameProcessor;
import org.springframework.boot.CommandLineRunner;
import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;

@SpringBootApplication
public class MinesweeperApplication implements CommandLineRunner {

	public static void main(String[] args) {
		SpringApplication.run(MinesweeperApplication.class, args);
	}

	@Override
	public void run(String... args) throws Exception {
		GameProcessor processor = new GameProcessor();
		processor.Initiate();
	}
}
