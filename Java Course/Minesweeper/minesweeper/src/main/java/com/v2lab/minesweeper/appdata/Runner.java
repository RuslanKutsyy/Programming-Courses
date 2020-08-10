package com.v2lab.minesweeper.appdata;

import java.util.*;

public class Runner {
    private Game game;
    private Scanner scanner = new Scanner(System.in);

    public Runner(Game game) {
        this.game = game;
    }

    public void Run(){
        System.out.println(GenerateGameRules());
        int type = Integer.parseInt(this.scanner.nextLine());
        int[] boardData = GetSizeAndNumberOfMines(type);
        String mine = "*";
        String activeState = "Active";
        String completeState = "Completed";

        int size = boardData[0];
        int minesCount = boardData[1];

        this.game.setBoard(size);
        this.game.genTileCount = size * size;
        fillEmptyBoardWithDashes(size);
        System.out.format(printCurrentBoardView(this.game, activeState));

        while (true){
            if (this.game.isLost || this.game.isWon){
                break;
            }
            System.out.println(showNextMoveMessage());
            int[] coordinates = enterYourMove(this.game, this.scanner);

            if (coordinates.length == 0){
                continue;
            }

            if (!this.game.isActive){
                AddMines(this.game, minesCount, coordinates);
                this.game.isActive = true;
            }

            int row = coordinates[0];
            int col = coordinates[1];

            if (game.board[row][col].contains(mine)){
                game.isLost = true;
                break;
            }

            int surroundedMines = getMinesNearCell(coordinates, game);
            if (surroundedMines > 0){
                game.board[row][col] = surroundedMines + "";
            } else {
                clearAllSurroundedCells(coordinates, this.game);
            }

            int undisplayedTiles = getNumberOfUndisplayedTiles(this.game);
            if (game.genTileCount - undisplayedTiles == game.minesCoordinates.size()){
                game.isWon = true;
                break;
            }
            System.out.println(printCurrentBoardView(this.game, activeState));
        }

        if (game.isWon){
            System.out.println("You win!");
        } else {
           System.out.println("You lost!");
        }

        System.out.println(printCurrentBoardView(this.game, completeState));
    }

    private int getNumberOfUndisplayedTiles(Game game) {
        int count = 0;
        String undisplayedTile = "-";

        for (int row = 0; row < game.board.length; row++) {
            for (int col = 0; col < game.board.length; col++) {
                if (game.board[row][col].equals(undisplayedTile)){
                    count++;
                }
            }
        }

        return count;
    }

    private void clearAllSurroundedCells(int[] coordinates, Game game) {
        int row = coordinates[0];
        int column = coordinates[1];


        for (int startRow = row - 1; startRow <= row + 1 ; startRow++) {
            for (int startCol = column - 1; startCol <= column + 1; startCol++) {
                if (startRow >= 0 && startRow < game.board.length && startCol >= 0 && startCol < game.board.length && game.board[startRow][startCol].contains("-")){
                    game.board[startRow][startCol] = " ";
                }
            }
        }
    }

    private int getMinesNearCell(int[] coordinates, Game game) {
        int row = coordinates[0];
        int column = coordinates[1];
        int minesCount = 0;
        String  mineSign = "*";

        for (int startRow = row - 1; startRow <= row + 1 ; startRow++) {
            for (int startCol = column - 1; startCol <= column + 1; startCol++) {
                if (startRow >= 0 && startRow < game.board.length && startCol >= 0 && startCol < game.board.length){
                    if (startRow == row && startCol== column){
                        continue;
                    }
                    if (game.board[startRow][startCol].contains(mineSign)){
                        minesCount++;
                    }
                }
            }
        }

        return minesCount;
    }

    private String showNextMoveMessage() {
        StringBuilder sb = new StringBuilder();

        sb.append("Enter your next move, (row, column) \n->");

        return sb.toString();
    }

    private int[] enterYourMove(Game game, Scanner scanner) {
        String[] input = scanner.nextLine().trim().split("\\s+");
        String[] moveInput = Arrays.stream(input).filter(x -> !x.isEmpty()).toArray(String[]::new);

        int row, column;

        try {
            row = Integer.parseInt(moveInput[0]);
            column = Integer.parseInt(moveInput[1]);
            if (row >= game.board.length || column >= game.board.length || row < 0 || column < 0){
                throw new IllegalArgumentException("Row or Column number is incorrect. Please enter the correct numbers separated with one space.");
            }
        } catch (Exception e){
            System.out.println(e.getMessage());
            return new int[0];
        }

        return new int[]{row, column};
    }

    private void AddMines(Game game, int count, int[] coordinates) {
        final String coordinatesString = coordinates[0] + " " + coordinates[1];
        final String mineIcon = "*";
        Random rand = new Random();
        for (int mine = 1; mine <= count; mine++) {
            int row = rand.nextInt(game.board.length);
            int col = rand.nextInt(game.board.length);
            String newMineCoordinates = row + " " + col;

            if (newMineCoordinates.equals(coordinatesString) || game.board[row][col].contains(mineIcon)){
                mine-= 1;
                continue;
            }
            game.board[row][col] = mineIcon;
            game.minesCoordinates.add(newMineCoordinates);
        }
    }

    private void fillEmptyBoardWithDashes(int size) {

        for (int row = 0; row < size; row++) {
            for (int column = 0; column < size; column++) {
                this.game.board[row][column] = "-";
            }
        }
    }

    private String printCurrentBoardView(Game currentGame, String state) {
        StringBuilder sb = new StringBuilder();
        sb.append("\t");
        for (int row = 0; row < currentGame.board.length; row++) {
            sb.append(row + " ");
        }
        sb.append("\n");

        for (int row = 0; row < currentGame.board.length; row++) {
            sb.append(row + "\t");
            for (int column = 0; column < this.game.board.length; column++) {
                String value = currentGame.board[row][column];
                if (value == "*" && state.equals("Active")){
                    value = "-";
                }
                if (column >= 10){value+=" ";};
                sb.append(value + " ");
            }
            sb.append("\n");
        }
        return sb.toString();
    }

    private String GenerateGameRules(){
        StringBuilder sb = new StringBuilder();

        sb.append("Enter the Difficulty Level\n");
        sb.append("Press 0 for BEGINNER (9 * 9 Cells and 10 Mines)\n");
        sb.append("Press 1 for INTERMEDIATE (16 * 16 Cells and 40 Mines)\n");
        sb.append("Press 2 for ADVANCED (24 * 24 Cells and 99 Mines)\n");

        return  sb.toString();
    }

    private int[] GetSizeAndNumberOfMines(int type){
        final Map<Integer, int[]> data = new HashMap<Integer, int[]>();
        data.put(0, new int[]{9, 10});
        data.put(1, new int[]{16, 40});
        data.put(2, new int[]{24, 99});

        return data.get(type);
    }
}
