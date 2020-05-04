package com.company;

import java.util.ArrayDeque;
import java.util.Scanner;

public class Main {

    public static void main(String[] args) {
        ArrayDeque<Integer> stack = new ArrayDeque<>();
        Scanner scanner = new Scanner(System.in);
        Integer num = Integer.parseInt(scanner.nextLine());

        if (num != 0){
            while (num != 0){
                stack.push(num % 2);
                num /= 2;
            }
        } else {
            stack.push(0);
        }
        stack.forEach(x->System.out.print(x));
    }
}
