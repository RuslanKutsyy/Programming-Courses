package com.company;

import java.util.ArrayDeque;
import java.util.Scanner;

public class Main {

    public static void main(String[] args) {
        ArrayDeque<String> history = new ArrayDeque<>();
        Scanner scanner = new Scanner(System.in);
        String cmd = scanner.nextLine();

        while (!cmd.equals("Home")){
            if (!cmd.equals("back")){
                history.push(cmd);
                System.out.println(cmd);
            } else {
                String textToPrint = "";
                if (history.size() > 0){
                    history.pop();
                    textToPrint = history.size() == 0 ? "no previous URLs" : history.peek();
                } else {
                    textToPrint = "no previous URLs";
                }
                System.out.println(textToPrint);
            }
            cmd = scanner.nextLine();
        }
    }
}