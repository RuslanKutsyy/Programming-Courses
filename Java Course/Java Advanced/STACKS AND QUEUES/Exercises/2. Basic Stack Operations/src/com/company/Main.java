package com.company;

import java.lang.reflect.Array;
import java.util.*;
import java.util.stream.Stream;

public class Main {

    public static void main(String[] args) {
        ArrayDeque<Integer> nums = new ArrayDeque<>();
        Scanner scanner = new Scanner(System.in);
        String[] input = scanner.nextLine().split(" ");
        Integer s = Integer.parseInt(input[1]);
        Integer x = Integer.parseInt(input[2]);
        Arrays.asList(scanner.nextLine().split(" ")).forEach(num -> nums.push(Integer.parseInt(num)));

        for (int i = 0; i < s; i++) {
            nums.pop();
        }

        if (nums.size() > 0){
            if (nums.contains(x)){
                System.out.println("true");
            } else {
                System.out.println(nums.stream().min(Integer::compareTo).get());
            }
        } else {
            System.out.println(0);
        }
    }
}