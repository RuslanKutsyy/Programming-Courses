package com.company;

import java.util.*;

public class Main {

    public static void main(String[] args) {
        ArrayDeque<Integer> stack = new ArrayDeque<>();
        Scanner scanner = new Scanner(System.in);
        String[] input = scanner.nextLine().split(" ");
        Arrays.asList(input).forEach(x -> stack.add(Integer.parseInt(x)));
        Iterator<Integer> iter = stack.descendingIterator();
        while (iter.hasNext()){
            System.out.print(iter.next() + " ");
        }
    }
}
