package com.company;

import java.util.ArrayDeque;
import java.util.Arrays;
import java.util.Scanner;

public class Main {

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        var input = Arrays.asList(scanner.nextLine().split(""));
        ArrayDeque<String> queue = new ArrayDeque<>(input);

        if (queue.size() % 2 > 0){
            System.out.println("NO");
        } else {
            if (isValid(queue)){
                System.out.println("YES");
            } else {
                System.out.println("NO");
            }
        }
    }

    private static Boolean isValid(ArrayDeque<String> data){
        ArrayDeque<String> openedBrackets = new ArrayDeque<>();
        while (data.size() > 0){
            String bracket = data.poll();
            switch (bracket){
                case "(":
                case "{":
                case "[":
                    openedBrackets.push(bracket);
                    break;
                default:
                    if (openedBrackets.size() == 0){
                        return false;
                    } else {
                        String firstBracket = openedBrackets.pop();
                        switch (firstBracket){
                            case "(":{
                                if (!bracket.equals(")")){
                                    return false;
                                }
                                break;
                            }
                            case "[":{
                                if (!bracket.equals("]")){
                                    return false;
                                }
                                break;
                            }
                            case "{":{
                                if (!bracket.equals("}")){
                                    return false;
                                }
                                break;
                            }
                        }
                    }
                    break;
            }
        }
        return true;
    }
}
