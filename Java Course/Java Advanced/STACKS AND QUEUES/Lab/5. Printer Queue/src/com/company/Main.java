package com.company;

import java.util.ArrayDeque;
import java.util.Scanner;

public class Main {

    public static void main(String[] args) {
        ArrayDeque<String> queue = new ArrayDeque<>();
        Scanner scanner = new Scanner(System.in);
        String cmd = scanner.nextLine();

        while (!cmd.equals("print")){
            if (!cmd.equals("cancel")){
                queue.offer(cmd);
            } else {
                if (queue.size() > 0) {
                    System.out.println("Canceled " + queue.remove());
                } else {
                    System.out.println("Printer is on standby");
                }
            }
            cmd = scanner.nextLine();
        }
        queue.forEach(x -> System.out.println(queue.pollFirst()));
    }
}
