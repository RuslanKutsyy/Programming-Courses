package com.company;

import java.util.ArrayDeque;
import java.util.Arrays;
import java.util.Scanner;

public class Main {

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String input = scanner.nextLine();
        ArrayDeque<String> queue = new ArrayDeque<>(Arrays.asList(input.split(" ")));
        Integer num = Integer.parseInt(scanner.nextLine());

        for (int i = 1; i <= num; i++) {
            if (queue.size() == 1) break;
            String name = queue.pollFirst();
            if (i == num){
                System.out.println("Removed " + name);
                i = 0;
            } else {
                queue.offer(name);
            }
        }
        System.out.println("Last is " + queue.pollFirst());
    }
}
