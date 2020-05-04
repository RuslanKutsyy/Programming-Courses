package com.company;

import java.util.*;

public class Main {

    public static void main(String[] args) {
        ArrayDeque<Integer> stack = new ArrayDeque<>();
        String expression = new Scanner(System.in).nextLine();
        String[] arr = expression.split("");

        for (int i = 0; i < arr.length; i++) {
            if (arr[i].equals("(")){
                stack.push(i);
            } else if (arr[i].equals(")")){
                System.out.println(expression.substring(stack.pop(), i + 1));
            }
        }
    }
}
