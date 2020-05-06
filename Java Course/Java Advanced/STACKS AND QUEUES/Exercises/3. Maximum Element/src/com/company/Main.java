package com.company;

import java.util.ArrayDeque;
import java.util.Arrays;
import java.util.Collections;
import java.util.Scanner;

public class Main {

    public static void main(String[] args) {
        ArrayDeque<Integer> stack = new ArrayDeque<>();
        Scanner scanner = new Scanner(System.in);
        Integer numsOfCommands = Integer.parseInt(scanner.nextLine());

        for (int i = 0; i < numsOfCommands; i++) {
            String[] cmd = scanner.nextLine().split(" ");
            switch (cmd[0]){
                case "1":{
                    stack.push(Integer.parseInt(cmd[1]));
                    break;
                }
                case "2":{
                    stack.pop();
                    break;
                }
                case "3":{
                    System.out.println(stack.stream().max(Integer::compareTo).get());
                    break;
                }
                default: break;
            }
        }
    }
}
