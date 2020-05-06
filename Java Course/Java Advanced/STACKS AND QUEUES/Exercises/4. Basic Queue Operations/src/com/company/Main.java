package com.company;

import java.util.*;

public class Main {

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        ArrayDeque<Integer> queue = new ArrayDeque<>();
        String[] inputData = scanner.nextLine().split(" ");
        Integer addToQueue = Integer.parseInt(inputData[0]);
        Integer toDequeue = Integer.parseInt(inputData[1]);
        Integer checkIfPresent = Integer.parseInt(inputData[2]);
        Arrays.asList(scanner.nextLine().split(" ")).forEach(x-> queue.offer(Integer.parseInt(x)));

        for (int i = 0; i < toDequeue; i++) {
            queue.poll();
        }

        if (queue.contains(checkIfPresent)){
            System.out.println("true");
        } else {
            if (queue.size() > 0){
                System.out.println(queue.stream().min(Integer::compareTo).get());
            } else {
                System.out.println(0);
            }
        }
    }
}